using Authentication.Microservice.Helper;
using Authentication.Microservice.Model;
using Authentication.Microservice.Service;
using JwtAuth.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentication.Microservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Users>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            var data = await userService.GetAll();
            return Ok(data);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> Get(Guid id)
        {
            try
            {
                var data = await userService.Get(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] Users value)
        {
            try
            {
                var result = await userService.Add(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Put([FromBody] Users value)
        {
            try
            {
                var result = await userService.Update(value);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await userService.Delete(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
