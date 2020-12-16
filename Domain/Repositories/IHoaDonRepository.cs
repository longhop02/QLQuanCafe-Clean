using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHoaDonRepository
    {
         IEnumerable<HoaDon> GetAll();

         HoaDon GetBy(int Id);

         void Add(HoaDon hd);

         void Update(HoaDon hd);

         void Remove(HoaDon hd);
    }
}