using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Models
{
    public class Page<T>
    {
        public int PageSize { get; }

        public int PageNumber { get; }

        public int TotalItems { get; }

        public T[] Items { get; }


        public Page(T[] items ,int totalItems, int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            Items = items;
            TotalItems = totalItems;
        }



    }

}
