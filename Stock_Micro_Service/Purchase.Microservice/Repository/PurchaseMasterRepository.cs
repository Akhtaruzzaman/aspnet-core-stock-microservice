using Infrastructure.Common.Repository;
using Purchase.Microservice.Model;
using Purchase.Microservice.Model.DBContext;
using Purchase.Microservice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase.Microservice.Repository
{
    public class PurchaseMasterRepository : BaseRepository<PurchaseMaster, Database_Context>, IPurchaseMasterRepository
    {
        public PurchaseMasterRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}