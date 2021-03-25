using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Common.Repository;
using Purchase.Microservice.Model;
using Purchase.Microservice.Model.DBContext;
using Purchase.Microservice.Repository.Interface;

namespace Purchase.Microservice.Repository
{
    public class PurchaseDetailsRepository : BaseRepository<PurchaseDetails, Database_Context>, IPurchaseDetailsRepository
    {
        public PurchaseDetailsRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}