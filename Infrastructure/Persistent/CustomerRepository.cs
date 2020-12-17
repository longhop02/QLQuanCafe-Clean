using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Domain.Entities.CustomerAggregate;

namespace Infrastructure.Persistent
{
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(QLQuanCafeContext context) : base(context)
        {
        }

        /*public IEnumerable<string> GetCustomerTypes()
        {
            return context.Customers
                            .OrderBy(m => m.CustomerType)
                            .Select(m => m.CustomerType)
                            .Distinct();
        }*/

        /*public IEnumerable<Customer> CustomerFilter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.Customers.AsQueryable();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.CustomerName.Contains(searchString));
            }

            SortCustomers(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }*/

        public IEnumerable<Customer> CustomerSearch(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.Customers.AsQueryable();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.CustomerName.Contains(searchString));
            }            
            SortCustomers(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        
        private static void SortCustomers(string sortOrder, ref IQueryable<Customer> query)
        {
            switch (sortOrder)
            {
                case "customerName_desc":
                    query = query.OrderByDescending(m => m.CustomerName);
                    break;
                case "customerName":
                    query = query.OrderBy(m => m.CustomerName);
                    break;
                case "customerPhoneNumber_desc":
                    query = query.OrderByDescending(m => m.CustomerPhoneNumber);
                    break;
                case "customerPhoneNumber":
                    query = query.OrderBy(m => m.CustomerPhoneNumber);
                    break;
                case "customerAddress_desc":
                    query = query.OrderByDescending(m => m.CustomerAddress);
                    break;
                case "customerAddress":
                    query = query.OrderBy(m => m.CustomerAddress);
                    break;
                case "customerEmail_desc":
                    query = query.OrderByDescending(m => m.CustomerEmail);
                    break;
                case "customerEmail":
                    query = query.OrderBy(m => m.CustomerEmail);
                    break;
                
            }
        }

        public string GetCustomerName (int customerId)
        {
            var query = context.Customers.First(c => c.Id == customerId);
            return query.CustomerName;
        }
    }
}