﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace basic_webapi.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }

        public PaginatedList(List<T> items, int count, int pageIdex, int pageSize)
        {
            PageIndex = pageIdex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageSize, int pageIndex)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1)*pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
