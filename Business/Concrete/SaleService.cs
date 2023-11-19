using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class SaleService : ISaleService
    {
        private readonly ISaleDal _saleDal;

        public SaleService(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public List<SaleDTO> GetAll()
        {
            return _saleDal.GetList()
                .Select(s => new SaleDTO()
                {
                    Id = s.Id,
                    Price = s.Price,
                    Date = s.Date,
                    CustomerId = s.CustomerId,
                    // ... diğer özellikler
                })
                .ToList();
        }

        public SaleDTO GetById(int saleId)
        {
            var sale = _saleDal.Get(s => s.Id == saleId);
            if (sale != null)
            {
                return new SaleDTO()
                {
                    Id = sale.Id,
                    Price = sale.Price,
                    Date = sale.Date,
                    CustomerId = sale.CustomerId,
                    
                };
            }
            return null;
        }

        public void Add(SaleDTO saleDto)
        {
            var sale = new Sale()
            {
                Id = saleDto.Id,
                Price = saleDto.Price,
                Date = saleDto.Date,
                CustomerId = saleDto.CustomerId,
                
            };
            _saleDal.Add(sale);
        }

        public void Update(SaleDTO saleDto)
        {
            var sale = _saleDal.Get(s => s.Id == saleDto.Id);
            if (sale != null)
            {
                sale.Price = saleDto.Price;
                sale.Date = saleDto.Date;
                sale.CustomerId = saleDto.CustomerId;
                

                _saleDal.Update(sale);
            }
        }

        public void Delete(int saleId)
        {
            var sale = _saleDal.Get(s => s.Id == saleId);
            if (sale != null)
            {
                _saleDal.Delete(sale);
            }
        }
    }
}
