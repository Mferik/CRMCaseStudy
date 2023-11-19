using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISaleService
    {
        List<SaleDTO> GetAll();
        SaleDTO GetById(int saleId);
        void Add(SaleDTO sale);
        void Update(SaleDTO sale);
        void Delete(int saleId);
    }
}
