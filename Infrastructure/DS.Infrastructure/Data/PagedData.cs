using DS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using PK.BuildingBlocks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DS.Infrastructure.SQL.Data
{
    public class PagedData<T> : IPagedData<T>
    {
        public PagedData()
        {

        }
        public PagedData(int pageIndex, int pageSize, IQueryable<T> query, bool isAsync)
        {
            setPagingOptions(pageIndex, pageSize, query, isAsync);
        }

        private async void setPagingOptions(int pageIndex, int pageSize, IQueryable<T> query, bool isAsync)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalItemCount = isAsync ? await query.CountAsync() : query.Count();
            PageCount = TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;

            HasPreviousPage = (PageIndex > 1);
            HasNextPage = (PageIndex < (PageCount - 1));
            IsFirstPage = (PageIndex == 1);
            IsLastPage = (PageIndex >= (PageCount - 1));

            ItemStart = (PageIndex - 1) * PageSize + 1;
            ItemEnd = Math.Min((PageIndex - 1) * PageSize + PageSize, TotalItemCount);

            if (pageSize > 0 && pageIndex == 1)
            {
                query = query.Take(pageSize);
            }
            else if (pageIndex > 1)
            {
                query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }

            Data = isAsync ? await query.ToListAsync() : query.ToList();
        }

        public async Task<IList<T>> getPagedData(int pageIndex, int pageSize, IQueryable<T> query, int totalCount)
        {
            TotalItemCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
            //TotalItemCount = await query.CountAsync();
            PageCount = TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;

            HasPreviousPage = (PageIndex > 1);
            HasNextPage = (PageIndex < (PageCount));
            IsFirstPage = (PageIndex == 1);
            IsLastPage = (PageIndex >= (PageCount));

            ItemStart = (PageIndex - 1) * PageSize + 1;
            ItemEnd = Math.Min((PageIndex - 1) * PageSize + PageSize, TotalItemCount);

            if (pageSize > 0 && pageIndex == 1)
            {
                query = query.Take(pageSize);
            }
            else if (pageIndex > 1)
            {
                query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }

            Data = await query.ToListAsync();
            return Data;
        }

        public async Task<IList<T>> getPagedDataAsync(int pageIndex, int pageSize, IQueryable<T> query, int totalCount)
        {
            TotalItemCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
            //TotalItemCount = await query.CountAsync();
            PageCount = TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;

            HasPreviousPage = (PageIndex > 1);
            HasNextPage = (PageIndex < (PageCount));
            IsFirstPage = (PageIndex == 1);
            IsLastPage = (PageIndex >= (PageCount));

            ItemStart = (PageIndex - 1) * PageSize + 1;
            ItemEnd = Math.Min((PageIndex - 1) * PageSize + PageSize, TotalItemCount);

            if (pageSize > 0 && pageIndex == 1)
            {
                query = query.Take(pageSize);
            }
            else if (pageIndex > 1)
            {
                query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }

            Data = await query.ToListAsync();
            return Data;
        }
        public void SetData(IList<T> data)
        {
            Data = data;
        }
        public void SetAll(IList<T> data, int _PageCount, int _TotalItemCount, int _PageIndex, bool _HasPreviousPage, bool _HasNextPage, bool _IsFirstPage, bool _IsLastPage, int _ItemStart, int _ItemEnd)
        {
            Data = data;
            PageCount = _PageCount;
            TotalItemCount = _TotalItemCount;
            PageIndex = _PageIndex;

            HasPreviousPage = _HasPreviousPage;
            HasNextPage = _HasNextPage;
            IsFirstPage = _IsFirstPage;
            IsLastPage = _IsLastPage;
            ItemStart = _ItemStart;
            ItemEnd = _ItemEnd;
        }
        public IList<T> Data { get; set; } = new List<T>();

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
