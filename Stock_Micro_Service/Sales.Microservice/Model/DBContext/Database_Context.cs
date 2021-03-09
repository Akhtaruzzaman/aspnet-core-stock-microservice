using Microsoft.EntityFrameworkCore;
using Sidecar.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Microservice.Model.DBContext
{
    public class Database_Context : DbContext
    {
        public Database_Context(DbContextOptions<Database_Context> options)
        : base(options)
        {
        }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<SalesDetails> SalesDetails { get; set; }
        public virtual DbSet<SalesMaster> SalesMaster { get; set; }
    }
}
