using Authentication.Microservice.Controllers;
using Authentication.Microservice.Model;
using Authentication.Microservice.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthenticationTest
{
    public class UsersTest
    {
        [Fact]
        public void PostValidUser()
        {
            var userService = new Mock<IUserService>();
            var user = new UsersController(userService.Object);
            Users value = new Users { };
            Assert.IsType<Task<ActionResult<OkResult>>>(user.Post(value));
        } 
        [Fact]
        public void PostInvlidUser()
        {
            var userService = new Mock<IUserService>();
            var user = new UsersController(userService.Object);
            Users value = new Users { };
            Assert.IsType<Task<ActionResult<BadRequestResult>>>(user.Post(value));
        }
    }
}
