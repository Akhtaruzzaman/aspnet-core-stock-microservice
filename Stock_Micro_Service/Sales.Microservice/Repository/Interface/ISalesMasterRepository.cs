using Infrastructure.Common.Repository;
using Sales.Microservice.Model;
using Sales.Microservice.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Microservice.Repository.Interface
{
    public interface ISalesMasterRepository : IBaseRepository<SalesMaster, Database_Context>
    {
    }
}
