using Authentication.Microservice.Model;
using Authentication.Microservice.Model.DBContext;
using Infrastructure.Common.Repository;

namespace Authentication.Microservice.Repository
{
    public interface IUserRepository : IBaseRepository<Users, Database_Context>
    {
    }
}
