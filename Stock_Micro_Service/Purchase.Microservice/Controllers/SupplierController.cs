using Purchase.Microservice.Model;
using Purchase.Microservice.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Purchase.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        ISupplierService supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Supplier>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Supplier>>> Get()
        {
            var data = await supplierService.GetAll();
            return Ok(data);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Supplier), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Supplier>> Get(Guid id)
        {
            try
            {
                var data = await supplierService.Get(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<SupplierController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] Supplier value)
        {
            try
            {
                var result = await supplierService.Add(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<SupplierController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Put([FromBody] Supplier value)
        {
            try
            {
                var result = await supplierService.Update(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await supplierService.Delete(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
