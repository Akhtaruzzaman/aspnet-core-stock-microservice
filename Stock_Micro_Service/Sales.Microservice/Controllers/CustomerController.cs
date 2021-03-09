using Sales.Microservice.Model;
using Sales.Microservice.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService productService;
        public CustomerController(ICustomerService productService)
        {
            this.productService = productService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var data = await productService.GetAll();
            return Ok(data);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Customer>> Get(Guid id)
        {
            try
            {
                var data = await productService.Get(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] Customer value)
        {
            try
            {
                var result = await productService.Add(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Put([FromBody] Customer value)
        {
            try
            {
                var result = await productService.Update(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await productService.Delete(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
