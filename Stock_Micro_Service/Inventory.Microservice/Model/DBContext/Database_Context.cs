using Microsoft.EntityFrameworkCore;
using Sidecar.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Microservice.Model.DBContext
{
    public class Database_Context : DbContext
    {
        public Database_Context(DbContextOptions<Database_Context> options)
        : base(options)
        {
        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
    }
}
