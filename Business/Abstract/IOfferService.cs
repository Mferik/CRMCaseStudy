using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOfferService
    {
        List<OfferDTO> GetAll();
        OfferDTO GetById(int offerId);
        void Add(OfferDTO offer);
        void Update(OfferDTO offer);
        void Delete(int offerId);
    }
}
