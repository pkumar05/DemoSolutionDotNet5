using PK.BuildingBlocks.Infrastructure;
using System.Collections.Generic;

namespace DS.Domain.DynamicQuery
{
    /// <summary>
    /// Pagination implementation used by data descriptor.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DescriptorPagedData<T> : IPagedData<T>
    {
        public IList<T> Data { get; set; }

        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageIndex { get; set; }
        public int PageNumber { get { return PageIndex; } }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int ItemStart { get; set; }
        public int ItemEnd { get; set; }
    }
}
