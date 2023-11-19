using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<CustomerDTO> GetAll()
        {
            return _customerDal.GetList()
                .Select(c => new CustomerDTO()
                {
                    Id = c.Id,
                    Email = c.Email,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber
                })
                .ToList();
        }

        public CustomerDTO GetById(int customerId)
        {
            var customer = _customerDal.Get(c => c.Id == customerId);
            if (customer != null)
            {
                return new CustomerDTO()
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber
                };
            }
            return null;
        }

        public void Add(CustomerDTO customerDto)
        {
            var customer = new Customer()
            {
                Id = customerDto.Id,
                Email = customerDto.Email,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                PhoneNumber = customerDto.PhoneNumber
            };
            _customerDal.Add(customer);
        }

        public void Update(CustomerDTO customerDto)
        {
            var customer = _customerDal.Get(c => c.Id == customerDto.Id);
            if (customer != null)
            {
                customer.Email = customerDto.Email;
                customer.FirstName = customerDto.FirstName;
                customer.LastName = customerDto.LastName;
                customer.PhoneNumber = customerDto.PhoneNumber;

                _customerDal.Update(customer);
            }
        }

        public void Delete(int customerId)
        {
            var customer = _customerDal.Get(c => c.Id == customerId);
            if (customer != null)
            {
                _customerDal.Delete(customer);
            }
        }
    }
}
