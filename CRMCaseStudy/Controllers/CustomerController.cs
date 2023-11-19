using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRMCaseStudy.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerDTO customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer object is null");
            }

            _customerService.Add(customer);
            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDTO customer)
        {
            if (customer == null || id != customer.Id)
            {
                return BadRequest("Invalid customer object");
            }

            var existingCustomer = _customerService.GetById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerService.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Delete(id);
            return NoContent();
        }
    }
}
