using Microsoft.AspNetCore.Mvc;
using Sales.Microservice.Model;
using Sales.Microservice.Service.Interface;
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
    public class SalesController : ControllerBase
    {
        private readonly ISalesMasterService salesMasterService;
        public SalesController(ISalesMasterService salesMasterService)
        {
            this.salesMasterService = salesMasterService;
        }
        // GET: api/<SalesController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SalesMaster>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SalesMaster>>> Get()
        {
            var data = await salesMasterService.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SalesMaster), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesMaster>> Get(Guid id)
        {
            try
            {
                var data = await salesMasterService.Get(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // POST api/<SalesMasterController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] SalesMaster value)
        {
            try
            {
                var result = await salesMasterService.Add(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<SalesMasterController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Put([FromBody] SalesMaster value)
        {
            try
            {
                var result = await salesMasterService.Update(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<SalesMasterController>/5
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await salesMasterService.Delete(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
