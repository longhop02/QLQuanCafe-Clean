using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Persistent;
using Domain.Repositories;

namespace Infrastructure.Persistent
{
    public class EFTheRepository : ITheRepository
    {
        private readonly QLQuanCafeContext context;

        public EFTheRepository(QLQuanCafeContext context){
            this.context = context;
        }

        public IEnumerable<The> GetAll(){

            return context.Thes.ToList();
        }

        public The GetBy(int Id){
            return context.Thes.Find(Id);
        }

        public The GetBy(string tenThe){
            return context.Thes.Find(tenThe);
        }

        public void Add(The the){
            context.Thes.Add(the);
            context.SaveChanges();
        }

        public void Update(The the){
            context.Thes.Update(the);
            context.SaveChanges();
        }

        public void Remove(The the){
            context.Thes.Remove(the);
            context.SaveChanges();
        }
    }
}