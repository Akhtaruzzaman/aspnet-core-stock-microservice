using Authentication.Microservice.Model;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Microservice.Service
{
    public interface IUserService : IBaseService<Users>
    {
        Task<IEnumerable<Users>> GetRole();
    }
}
