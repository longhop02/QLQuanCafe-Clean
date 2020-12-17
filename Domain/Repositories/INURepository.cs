using System.Collections.Generic;
using Domain.Entities;


namespace Domain.Repositories
{
    public interface INURepository 
    {
         IEnumerable<NuocUong> GetAll();

         NuocUong GetBy(int Id);

         void Add(NuocUong nu);

         void Update(NuocUong nu);

         void Remove(NuocUong nu);
    }
}