using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class OfferService : IOfferService
    {
        private readonly IOfferDal _offerDal;

        public OfferService(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        public List<OfferDTO> GetAll()
        {
            return _offerDal.GetList()
                .Select(o => new OfferDTO()
                {
                    Id = o.Id,
                    Price = o.Price,
                    Date = o.Date,
                    CustomerId = o.CustomerId,
                    
                })
                .ToList();
        }

        public OfferDTO GetById(int offerId)
        {
            var offer = _offerDal.Get(o => o.Id == offerId);
            if (offer != null)
            {
                return new OfferDTO()
                {
                    Id = offer.Id,
                    Price = offer.Price,
                    Date = offer.Date,
                    CustomerId = offer.CustomerId,
                    
                };
            }
            return null;
        }

        public void Add(OfferDTO offerDto)
        {
            var offer = new Offer()
            {
                Id = offerDto.Id,
                Price = offerDto.Price,
                Date = offerDto.Date,
                CustomerId = offerDto.CustomerId,
                
            };
            _offerDal.Add(offer);
        }

        public void Update(OfferDTO offerDto)
        {
            var offer = _offerDal.Get(o => o.Id == offerDto.Id);
            if (offer != null)
            {
                offer.Price = offerDto.Price;
                offer.Date = offerDto.Date;
                offer.CustomerId = offerDto.CustomerId;
                

                _offerDal.Update(offer);
            }
        }

        public void Delete(int offerId)
        {
            var offer = _offerDal.Get(o => o.Id == offerId);
            if (offer != null)
            {
                _offerDal.Delete(offer);
            }
        }
    }
}
