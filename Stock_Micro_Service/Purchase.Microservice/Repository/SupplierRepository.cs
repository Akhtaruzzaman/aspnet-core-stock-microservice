using Infrastructure.Common.Repository;
using Purchase.Microservice.Model;
using Purchase.Microservice.Model.DBContext;
using Purchase.Microservice.Repository.Interface;

namespace Purchase.Microservice.Repository
{
    public class SupplierRepository : BaseRepository<Supplier, Database_Context>, ISupplierRepository
    {
        public SupplierRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}