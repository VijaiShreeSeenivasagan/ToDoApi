using System;
using System.Collections.Generic;
namespace TodoApi.Data.Paging
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

        }
//hides prevoius page for first page
        public bool HasPreviousPage
        {
            get { return (PageIndex > 1); }
        }
//hides next page for last page
        public bool HasNextPage
        {
            get { return (PageIndex < TotalPages); }
        }
    

    public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize){
        var count = source.Count();
        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return new PaginatedList<T>(items , count , pageIndex,pageSize);
    }
    }
}