using Authentication.Microservice.Model;
using Authentication.Microservice.Model.ViewModel;
using Authentication.Microservice.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Util.Common;

namespace Authentication.Microservice.Service
{
    public class UserService : BaseService<Users>, IUserService
    {

        private IUserRepository _userRepository;
        private IUserRoleRepository _userRoleRepository; 
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IOptions<AppSettings> appSettings) : base(userRepository)
        {
            this._userRepository = userRepository;
            this._userRoleRepository = userRoleRepository;
            this._appSettings = appSettings.Value;
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

        public async Task<string> Authenticate(LoginVm value)
        {
            var user = _userRepository.GetAll(x => x.email == value.email && x.password == value.password).FirstOrDefault();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return token;
        }
        private string generateJwtToken(Users user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
