using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Common.Repository;
using Sales.Microservice.Model;
using Sales.Microservice.Model.DBContext;
using Sales.Microservice.Repository.Interface;
namespace Sales.Microservice.Repository
{
    public class SalesDetailsRepository : BaseRepository<SalesDetails, Database_Context>, ISalesDetailsRepository
    {
        public SalesDetailsRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}