﻿using Authentication.Microservice.Model;
using Authentication.Microservice.Model.DBContext;
using Infrastructure.Common.Repository;

namespace Authentication.Microservice.Repository
{
    public class UserRepository : BaseRepository<Users, Database_Context>, IUserRepository
    {
        public UserRepository() : base(Database_Context())
        {

        }
    }
}
