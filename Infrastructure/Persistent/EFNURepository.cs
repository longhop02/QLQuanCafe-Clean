using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Persistent;
using Domain.Repositories;

namespace Infrastructure.Persistent
{
    public class EFNURepository : INURepository
    {
        private readonly QLQuanCafeContext context;

        public EFNURepository(QLQuanCafeContext context){
            this.context = context;
        }

        public void Add(NuocUong nu)
        {
            context.NUs.Add(nu);
            context.SaveChanges();
        }

        public IEnumerable<NuocUong> GetAll()
        {
            return context.NUs.ToList();
        }

        public NuocUong GetBy(int Id)
        {
            return context.NUs.Find(Id);
        }

        public void Remove(NuocUong nu)
        {
            context.NUs.Remove(nu);
            context.SaveChanges();
        }

        public void Update(NuocUong nu)
        {
            context.NUs.Update(nu);
            context.SaveChanges();
        }
    }
}