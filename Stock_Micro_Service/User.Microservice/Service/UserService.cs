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

        public async Task<IEnumerable<Users>> GetRole()
        {
            try
            {
                var query = (from t1 in _userRepository.GetAll()
                             join _t2 in _userRoleRepository.GetAll() on t1.Id equals _t2.UsersId into t2_
                             from t2 in t2_.DefaultIfEmpty()
                             where t2.Sn > 1
                             select new
                             {
                                 t1,
                                 t2
                             });

                var s = query.AsEnumerable()
                    .GroupBy(tg => tg.t1.Id, (key, items) => new Users
                    {
                        Id = items.FirstOrDefault().t1.Id,
                        name = items.FirstOrDefault().t1.name,
                        TotalRole = items.Sum(x => x.t2 == null ? 0 : x.t2.Sn),
                    });

                return s;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
