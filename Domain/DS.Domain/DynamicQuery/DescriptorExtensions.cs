using PK.BuildingBlocks.Infrastructure;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace DS.Domain.DynamicQuery
{
    /// <summary>
    /// Extension methods to apply data descriptor.
    /// AKJ.
    /// </summary>
    public static class DescriptorExtensions
    {
        public static IQueryable<T> ApplyDescriptor<T, TProperties>(this IQueryable<T> query, DataDescriptor descriptor)
        {
            if (descriptor == null)
                return query;

            if (descriptor.Order != null && !string.IsNullOrEmpty(descriptor.Order.OrderBy))
            {
                var property = typeof(TProperties).GetProperties().FirstOrDefault(e => string.Equals(e.Name, descriptor.Order.OrderBy, StringComparison.InvariantCultureIgnoreCase));

                if (property == null)
                    throw new DescriptorException("Invalid OrderBy property name.");

                var attr = property.GetCustomAttribute<SourcePropertyAttribute>();
                var propertyName = property.Name;
                if (attr != null)
                    propertyName = attr.Name;

                descriptor.Order.OrderBy = propertyName;

                query = ApplyOrderByInner(query, descriptor.Order);
            }
            if (descriptor.Filter != null)
            {
                foreach (var filterDescription in descriptor.Filter)
                {
                    var property = typeof(TProperties).GetProperties().FirstOrDefault(e => string.Equals(e.Name, filterDescription.FilterBy, StringComparison.InvariantCultureIgnoreCase));

                    if (property == null)
                        throw new DescriptorException("Invalid FilterBy property name.");

                    var attr = property.GetCustomAttribute<SourcePropertyAttribute>();
                    var propertyName = property.Name;
                    if (attr != null)
                    {
                        propertyName = attr.Name;
                        property = typeof(T).GetProperty(propertyName);
                    }

                    filterDescription.FilterBy = propertyName;

                    query = ApplyFilterInner(query, filterDescription, property.PropertyType);
                }
            }
            return query;
        }

        public static IQueryable<T> ApplyDescriptor<T>(this IQueryable<T> query, DataDescriptor descriptor)
        {
            if (descriptor == null)
                return query;
            if (descriptor.Order != null && !string.IsNullOrEmpty(descriptor.Order.OrderBy))
            {
                var property = typeof(T).GetProperties().FirstOrDefault(e => string.Equals(e.Name, descriptor.Order.OrderBy, StringComparison.InvariantCultureIgnoreCase));

                if (property == null)
                    throw new DescriptorException("Invalid OrderBy property name.");

                descriptor.Order.OrderBy = property.Name;

                query = ApplyOrderByInner(query, descriptor.Order);
            }

            if (descriptor.Filter != null)
            {
                foreach (var filterDescription in descriptor.Filter)
                {
                    var property = typeof(T).GetProperties().FirstOrDefault(e => string.Equals(e.Name, filterDescription.FilterBy, StringComparison.InvariantCultureIgnoreCase));

                    if (property == null)
                        throw new DescriptorException("Invalid Filter property name.");

                    filterDescription.FilterBy = property.Name;

                    query = ApplyFilterInner(query, filterDescription, property.PropertyType);
                }
            }

            return query;
        }

        public static IPagedData<T> ApplyDescriptorWithPagination<T>(this IQueryable<T> query, DataDescriptor descriptor)
        {
            if (descriptor == null)
                descriptor = new DataDescriptor();
            if (descriptor.Pagination == null || descriptor.Pagination.PageSize == -1)
                descriptor.Pagination = PaginationDescriptor.NoPagination;


            return query.ApplyDescriptor(descriptor).ApplyPagination(descriptor);
        }

        public static IPagedData<TResult> ApplyDescriptorWithPagination<T, TResult>(this IQueryable<T> query, DataDescriptor descriptor, Func<T, TResult> transform)
        {
            if (descriptor == null)
                descriptor = new DataDescriptor();
            if (descriptor.Pagination == null || descriptor.Pagination.PageSize == -1)
                descriptor.Pagination = PaginationDescriptor.NoPagination;


            return query.ApplyDescriptor<T, TResult>(descriptor).AsEnumerable().Select(transform).AsQueryable().ApplyPagination(descriptor);
        }

        public static IPagedData<T> ApplyPagination<T>(this IQueryable<T> query, DataDescriptor descriptor)
        {
            var result = new DescriptorPagedData<T>();
            var totalCount = query.Count();

            if (descriptor == null)
                descriptor = new DataDescriptor();

            if (descriptor.Pagination == null)
                descriptor.Pagination = PaginationDescriptor.NoPagination;

            var pageSize = descriptor.Pagination.PageSize;
            var pageIndex = descriptor.Pagination.PageIndex;

            result.TotalItemCount = totalCount;
            result.PageSize = descriptor.Pagination.PageSize;
            result.PageIndex = descriptor.Pagination.PageIndex;
            result.PageCount = result.TotalItemCount > 0 ? (int)Math.Ceiling(result.TotalItemCount / (double)pageSize) : 0;
            result.HasPreviousPage = (pageIndex > 1);
            result.HasNextPage = (pageIndex < (result.PageCount));
            result.IsFirstPage = (pageIndex == 1);
            result.IsLastPage = (pageIndex >= (result.PageCount));
            result.ItemStart = (pageIndex - 1) * pageSize + 1;
            result.ItemEnd = Math.Min((pageIndex - 1) * pageSize + pageSize, result.TotalItemCount);

            if (pageSize > 0 && pageIndex == 1)
            {
                query = query.Take(pageSize);
            }
            else if (pageIndex > 1)
            {
                query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }

            result.Data = query.ToList();
            return (IPagedData<T>)result;
        }

        private static IQueryable<T> ApplyOrderByInner<T>(IQueryable<T> query, OrderDescriptor descriptor)
        {

            var argEx = Expression.Parameter(typeof(T), "e");
            var propertyEx = Expression.Property(argEx, descriptor.OrderBy);
            var conversion = Expression.Convert(propertyEx, typeof(object));
            var expression = Expression.Lambda<Func<T, object>>(conversion, argEx);

            if (string.IsNullOrEmpty(descriptor.OrderType))
                descriptor.OrderType = OrderType.Ascending;

            if (descriptor.OrderType.ToUpperInvariant() == OrderType.Ascending)
                query = query.OrderBy(expression);
            else if (descriptor.OrderType.ToUpperInvariant() == OrderType.Descending)
                query = query.OrderByDescending(expression);
            else
                throw new DescriptorException("Invalid order type.");

            return query;
        }

        private static IQueryable<T> ApplyFilterInner<T>(IQueryable<T> query, FilterDescription descriptor, Type propertyType)
        {
            if (string.IsNullOrEmpty(descriptor.FilterType))
                descriptor.FilterType = FilterType.Contain;

            var argEx = Expression.Parameter(typeof(T), "e");
            var propertyEx = Expression.Property(argEx, descriptor.FilterBy);

            var conversion = Expression.Convert(propertyEx, typeof(object));
            var nullExpression = Expression.NotEqual(conversion, Expression.Constant(null, typeof(object)));

            Expression body;

            if (descriptor.FilterType.ToUpperInvariant() == FilterType.Equal)
            {
                if (propertyType == typeof(DateTime))
                {
                    body = Expression.Call(propertyEx, GetDateToStringMethodInfo(), Expression.Constant("s"));
                    body = Expression.Equal(body, Expression.Constant(descriptor.Value));
                }
                else if (propertyType == typeof(DateTime?))
                {
                    body = Expression.Call(propertyEx, GetValueOrDefaultMethodInfo());
                    body = Expression.Call(body, GetDateToStringMethodInfo(), Expression.Constant("s"));
                    body = Expression.Call(body, GetStringContainsMethodInfo(), Expression.Constant(descriptor.Value), Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    body = Expression.Call(propertyEx, GetToStringMethodInfo(propertyType));
                    body = Expression.Equal(body, Expression.Constant(descriptor.Value));
                }
            }
            else if (descriptor.FilterType.ToUpperInvariant() == FilterType.NotEqual)
            {
                if (propertyType == typeof(DateTime))
                {
                    body = Expression.Call(propertyEx, GetDateToStringMethodInfo(), Expression.Constant("s"));
                    body = Expression.NotEqual(body, Expression.Constant(descriptor.Value));
                }
                else if (propertyType == typeof(DateTime?))
                {
                    body = Expression.Call(propertyEx, GetValueOrDefaultMethodInfo());
                    body = Expression.Call(body, GetDateToStringMethodInfo(), Expression.Constant("s"));
                    body = Expression.Call(body, GetStringContainsMethodInfo(), Expression.Constant(descriptor.Value), Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    body = Expression.Call(propertyEx, GetToStringMethodInfo(propertyType));
                    body = Expression.NotEqual(body, Expression.Constant(descriptor.Value));
                }
            }
            else if (descriptor.FilterType.ToUpperInvariant() == FilterType.Contain)
            {
                if (propertyType == typeof(DateTime))
                {
                    body = Expression.Call(propertyEx, GetDateToStringMethodInfo(), Expression.Constant("s"));
                    body = Expression.Call(body, GetStringContainsMethodInfo(), Expression.Constant(descriptor.Value), Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
                }
                else if (propertyType == typeof(DateTime?))
                {
                    body = Expression.Call(propertyEx, GetValueOrDefaultMethodInfo());
                    body = Expression.Call(body, GetDateToStringMethodInfo(), Expression.Constant("s"));
                    body = Expression.Call(body, GetStringContainsMethodInfo(), Expression.Constant(descriptor.Value), Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    body = Expression.Call(propertyEx, GetToStringMethodInfo(propertyType));
                    body = Expression.Call(body, GetStringContainsMethodInfo(), Expression.Constant(descriptor.Value), Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
                }
            }
            else
                throw new DescriptorException("Invalid filter type.");

            var final = Expression.AndAlso(nullExpression, body);
            var expression = Expression.Lambda<Func<T, bool>>(final, argEx);

            query = query.Where(expression);

            return query;
        }

        private static MethodInfo GetStringContainsMethodInfo()
        {
            return typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string), typeof(StringComparison) });
        }

        private static MethodInfo GetDateToStringMethodInfo()
        {
            return typeof(DateTime).GetMethod(nameof(object.ToString), new[] { typeof(string) });
        }

        private static MethodInfo GetValueOrDefaultMethodInfo()
        {
            return typeof(DateTime?).GetMethod(nameof(Nullable<DateTime>.GetValueOrDefault), Type.EmptyTypes);
        }

        private static MethodInfo GetToStringMethodInfo(Type propertyType)
        {
            return propertyType.GetMethod(nameof(object.ToString), Type.EmptyTypes);
        }
    }

    [Serializable]
    public class DescriptorException : Exception
    {
        public DescriptorException()
        {
        }

        public DescriptorException(string message) : base(message)
        {
        }

        public DescriptorException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DescriptorException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
