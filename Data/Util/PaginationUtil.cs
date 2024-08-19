using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Util
{
    public static class PaginationUtil
    {
        public static async Task<PagedResult<T>> PaginateAsync<T>(IQueryable<T> query, int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Parâmetros de paginação inválidos. pageNumber deve ser maior ou igual a 1 e pageSize deve ser maior que 0.");
            }

            var skip = (pageNumber - 1) * pageSize;
            var items = await query.Skip(skip).Take(pageSize).ToListAsync();

            return new PagedResult<T>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalCount = await query.CountAsync(),
                Items = items
            };
        }
    }

    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
        public string DDDFiltro { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
