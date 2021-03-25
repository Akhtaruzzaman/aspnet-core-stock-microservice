using Infrastructure.Common.Repository;
using Purchase.Microservice.Model;
using Purchase.Microservice.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase.Microservice.Repository.Interface
{
    public interface IPurchaseMasterRepository : IBaseRepository<PurchaseMaster, Database_Context>
    {
    }
}
