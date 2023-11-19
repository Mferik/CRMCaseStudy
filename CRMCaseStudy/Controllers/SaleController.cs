using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRMCaseStudy.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sales = _saleService.GetAll();
            return Ok(sales);
        }

        [HttpGet("{id}", Name = "GetSale")]
        public IActionResult Get(int id)
        {
            var sale = _saleService.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SaleDTO sale)
        {
            if (sale == null)
            {
                return BadRequest("Sale object is null");
            }

            _saleService.Add(sale);
            return CreatedAtRoute("GetSale", new { id = sale.Id }, sale);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaleDTO sale)
        {
            if (sale == null || id != sale.Id)
            {
                return BadRequest("Invalid sale object");
            }

            var existingSale = _saleService.GetById(id);
            if (existingSale == null)
            {
                return NotFound();
            }

            _saleService.Update(sale);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sale = _saleService.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }

            _saleService.Delete(id);
            return NoContent();
        }
    }
}
