using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistent
{
    public class EFHoaDonRepository : IHoaDonRepository
    {
        private readonly QLQuanCafeContext context;

        public EFHoaDonRepository(QLQuanCafeContext context){
            this.context = context;
        }
        public void Add(HoaDon hd)
        {
            context.HDs.Add(hd);
            context.SaveChanges();
        }

        public IEnumerable<HoaDon> GetAll()
        {
            return context.HDs.ToList();
        }

        public HoaDon GetBy(int Id)
        {
            return context.HDs.Find(Id);
        }

        public void Remove(HoaDon hd)
        {
            context.HDs.Remove(hd);
            context.SaveChanges();
        }

        public void Update(HoaDon hd)
        {
            context.HDs.Update(hd);
            context.SaveChanges();
        }
    }
}