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
    public class PurchaseController : ControllerBase
    {
        IPurchaseMasterService purchaseMasterService;
        public PurchaseController(IPurchaseMasterService purchaseMasterService)
        {
            this.purchaseMasterService = purchaseMasterService;
        }
        // GET: api/<PurchaseMasterController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PurchaseMaster>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PurchaseMaster>>> Get()
        {
            var data = await purchaseMasterService.GetAll();
            return Ok(data);
        }

        // GET api/<PurchaseMasterController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PurchaseMaster), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseMaster>> Get(Guid id)
        {
            try
            {
                var data = await purchaseMasterService.Get(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<PurchaseMasterController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] PurchaseMaster value)
        {
            try
            {
                var result = await purchaseMasterService.Add(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<PurchaseMasterController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Put([FromBody] PurchaseMaster value)
        {
            try
            {
                var result = await purchaseMasterService.Update(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<PurchaseMasterController>/5
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await purchaseMasterService.Delete(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
