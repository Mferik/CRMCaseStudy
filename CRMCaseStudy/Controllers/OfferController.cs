using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRMCaseStudy.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var offers = _offerService.GetAll();
            return Ok(offers);
        }

        [HttpGet("{id}", Name = "GetOffer")]
        public IActionResult Get(int id)
        {
            var offer = _offerService.GetById(id);
            if (offer == null)
            {
                return NotFound();
            }
            return Ok(offer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OfferDTO offer)
        {
            if (offer == null)
            {
                return BadRequest("Offer object is null");
            }

            _offerService.Add(offer);
            return CreatedAtRoute("GetOffer", new { id = offer.Id }, offer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OfferDTO offer)
        {
            if (offer == null || id != offer.Id)
            {
                return BadRequest("Invalid offer object");
            }

            var existingOffer = _offerService.GetById(id);
            if (existingOffer == null)
            {
                return NotFound();
            }

            _offerService.Update(offer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var offer = _offerService.GetById(id);
            if (offer == null)
            {
                return NotFound();
            }

            _offerService.Delete(id);
            return NoContent();
        }
    }
}
