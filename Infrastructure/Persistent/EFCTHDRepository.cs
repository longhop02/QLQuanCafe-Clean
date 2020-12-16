using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistent
{
    public class EFCTHDRepository : ICTHDRepository
    {
         private readonly QLQuanCafeContext context;

         public EFCTHDRepository(QLQuanCafeContext context){
             this.context = context;
         }
        public IEnumerable<ChiTietHoaDon> GetAll()
        {
            return context.CTHDs.ToList();
        }

        public ChiTietHoaDon GetBy(int Id)
        {
            return context.CTHDs.Find(Id);
        }

        public void Add(ChiTietHoaDon cthd)
        {
            context.CTHDs.Add(cthd);
            context.SaveChanges();
        }

        public void Update(ChiTietHoaDon cthd)
        {
            context.CTHDs.Update(cthd);
            context.SaveChanges();
        }

        public void Remove(ChiTietHoaDon cthd)
        {
            context.CTHDs.Remove(cthd);
            context.SaveChanges();
        }
    }
}