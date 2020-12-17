using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistent
{
    public class NuocUongRepository : EFRepository<NuocUong>, INuocUongRepository
    {
        public NuocUongRepository(QLQuanCafeContext context) : base(context)
        {
        }

        /*public IEnumerable<string> GetNuocUongTypes()
        {
            return context.NuocUongs
                            .OrderBy(m => m.NuocUongType)
                            .Select(m => m.NuocUongType)
                            .Distinct();
        }*/

        /*public IEnumerable<NuocUong> NuocUongFilter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.NuocUongs.AsQueryable();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.NuocUongName.Contains(searchString));
            }

            SortNuocUongs(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }*/

        public IEnumerable<NuocUong> NuocUongSearch(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.NUs.AsQueryable();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.TenNU.Contains(searchString));
            }            
            SortNuocUongs(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        
        private static void SortNuocUongs(string sortOrder, ref IQueryable<NuocUong> query)
        {
            switch (sortOrder)
            {
                case "id_desc":
                    query = query.OrderByDescending(m => m.Id);
                    break;
                case "id":
                    query = query.OrderBy(m => m.Id);
                    break;
                case "TenNU_desc":
                    query = query.OrderByDescending(m => m.TenNU);
                    break;
                case "TenNU":
                    query = query.OrderBy(m => m.TenNU);
                    break;
                case "donGia_desc":
                    query = query.OrderByDescending(m => m.DonGia);
                    break;
                case "donGia":
                    query = query.OrderBy(m => m.DonGia);
                    break;
                
                
            }
        }

    }
}