using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDSNURepository
    {
         IEnumerable<NuocUongThe> GetAll();

         NuocUongThe GetBy(int Id);

         void Add(NuocUongThe dsnu);
         void Update(NuocUongThe dsnu);
         void Remove(NuocUongThe dsnu);
    }
}