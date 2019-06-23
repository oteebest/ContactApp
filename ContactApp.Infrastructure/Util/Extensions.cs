using ContactApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Infrastructure.Util
{
    public static class Extensions
    {
        public static async Task<Page<T>> ToPagedListAsync<T>(this IOrderedQueryable<T> query,int pageNumber, int pageSize)
        {
            int totalItems = query.Count();

            var items = await query.Skip(pageNumber * pageSize).Take(pageSize).ToArrayAsync();

           return  new Page<T>(items, totalItems, pageSize, pageNumber);

        }

        public static Page<TResult> Select<T, TResult>(this Page<T> page, Func<T, TResult> selector)
        {
            var mapped = page.Items.Select(selector).ToArray();
            return new Page<TResult>(mapped, page.TotalItems,  page.PageSize, page.PageNumber);
        }

    }
}
