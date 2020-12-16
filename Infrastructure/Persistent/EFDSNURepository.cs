using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Persistent;
using Domain.Repositories;

namespace Infrastructure.Persistent
{
    public class EFDSNURepository : IDSNURepository
    {
        private readonly QLQuanCafeContext context;

        public EFDSNURepository(QLQuanCafeContext context){
            this.context = context;
        }
        public void Add(NuocUongThe nut)
        {
            context.DSNU.Add(nut);
            context.SaveChanges();
        }

        public IEnumerable<NuocUongThe> GetAll()
        {
            return context.DSNU.ToList();
        }

        public NuocUongThe GetBy(int Id)
        {
            return context.DSNU.Find(Id);
        }

        public void Remove(NuocUongThe nut)
        {
            context.DSNU.Remove(nut);
            context.SaveChanges();
        }

        public void Update(NuocUongThe nut)
        {
            context.DSNU.Update(nut);
            context.SaveChanges();
        }
    }
}