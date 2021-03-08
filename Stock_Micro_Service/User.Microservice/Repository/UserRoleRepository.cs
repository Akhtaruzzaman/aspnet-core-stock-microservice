using Authentication.Microservice.Model;
using Authentication.Microservice.Model.DBContext;
using Infrastructure.Common.Repository;

namespace Authentication.Microservice.Repository
{
    public class UserRoleRepository : BaseRepository<UserRole, Database_Context>, IUserRoleRepository
    {
        public UserRoleRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}
