using Inventory.Microservice.Model;
using Inventory.Microservice.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        IStockService stockService;
        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }
        // GET: api/<StockController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Stock>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Stock>> Get()
        {
            var data = stockService.GetAllStock();
            return Ok(data);
        }
        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public ActionResult<Stock> Get(Guid id)
        {
            var data = stockService.GetStockbyProductId(id);
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] Stock value)
        {
            try
            {
                var result = await stockService.Add(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
