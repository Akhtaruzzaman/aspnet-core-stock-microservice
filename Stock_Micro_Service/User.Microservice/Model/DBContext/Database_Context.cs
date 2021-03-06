using Microsoft.EntityFrameworkCore;
using Sidecar.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Microservice.Model.DBContext
{
    public class Database_Context : DbContext
    {
        public Database_Context(DbContextOptions<Database_Context> options)
        : base(options)
        {
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
    }
}
