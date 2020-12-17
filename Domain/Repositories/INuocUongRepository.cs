using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface INuocUongRepository : IRepository<NuocUong>
    {
         IEnumerable<NuocUong> NuocUongSearch(string sortOder, string searchString, int pageIndex, int pageSize, out int count);
    }
}