using Authentication.Microservice.Model;
using Authentication.Microservice.Repository;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Microservice.Service
{
    public class UserService : BaseService<Users>, IUserService
    {
       
        private IUserRepository _userRepository;
        private IUserRoleRepository _userRoleRepository;
        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository) : base(userRepository)
        {
            this._userRepository = userRepository;
            this._userRoleRepository = userRoleRepository;
        }

        public Task<List<Users>> GetRole()
        {
            try
            {
                var s = (from t1 in _userRepository.GetAll()
                         join t2 in _userRoleRepository.GetAll() on t1.Id equals t2.UsersId
                         select t1).ToList();

                return Task.FromResult(s);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
