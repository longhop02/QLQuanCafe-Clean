using System;
using System.Collections.Generic;
using Domain.Entities.CustomerAggregate;

namespace Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        //IEnumerable<string> GetCustomerTypes();
        IEnumerable<Customer> CustomerSearch(string sortOder, string searchString, int pageIndex, int pageSize, out int count);
        //IEnumerable<Customer> CustomerSearch(string sortOder, string searchString, out int count);
        string GetCustomerName(int customerId);
    }
} 