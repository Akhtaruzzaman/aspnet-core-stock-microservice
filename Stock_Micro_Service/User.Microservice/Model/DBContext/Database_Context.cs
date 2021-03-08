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
        public Database_Context()
            : base(GetOptions())
        {
        }

        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), SYS_DATA.DB_Connection).Options;
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
    }
}
