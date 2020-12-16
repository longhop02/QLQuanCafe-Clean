using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICTHDRepository
    {
         IEnumerable<ChiTietHoaDon> GetAll();

         ChiTietHoaDon GetBy(int Id);

         void Add(ChiTietHoaDon cthd);

         void Update(ChiTietHoaDon cthd);

         void Remove(ChiTietHoaDon cthd);
    }
}