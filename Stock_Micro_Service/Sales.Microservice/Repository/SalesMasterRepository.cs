using Infrastructure.Common.Repository;
using Sales.Microservice.Model;
using Sales.Microservice.Model.DBContext;
using Sales.Microservice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Microservice.Repository
{
    public class SalesMasterRepository : BaseRepository<SalesMaster, Database_Context>, ISalesMasterRepository
    {
        public SalesMasterRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}