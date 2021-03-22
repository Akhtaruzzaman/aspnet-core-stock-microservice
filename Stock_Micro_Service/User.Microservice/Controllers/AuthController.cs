using Authentication.Microservice.Model.ViewModel;
using Authentication.Microservice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Authentication.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/<UsersController>
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> GetToken([FromBody] LoginVm value)
        {
            string response = await userService.Authenticate(value);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
