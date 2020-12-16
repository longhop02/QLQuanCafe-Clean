using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITheRepository
    {
        IEnumerable<The> GetAll();
        
        The GetBy(int Id);

        The GetBy(string tenThe);
        void Add(The the);

        void Update(The the);

        void Remove(The the);
    }
}