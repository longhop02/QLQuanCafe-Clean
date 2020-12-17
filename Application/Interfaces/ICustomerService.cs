using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetCustomers(string sortOrder, string searchString, int pageIndex, int pageSize, out int count );

        CustomerDto GetCustomer(int CustomerId);
        //IEnumerable<string> GetTypes();
        void CreateCustomer(CustomerDto Customer);
        void UpdateCustomer(CustomerDto Customer);
        void DeleteCustomer(int CustomerId);
    }
}