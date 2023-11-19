using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<CustomerDTO> GetAll();
        CustomerDTO GetById(int customerId);
        void Add(CustomerDTO customer);
        void Update(CustomerDTO customer);
        void Delete(int customerId);
    }
}
