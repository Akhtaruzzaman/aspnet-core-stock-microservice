using Infrastructure.Common.Repository;
using Purchase.Microservice.Model;
using Purchase.Microservice.Model.DBContext;

namespace Purchase.Microservice.Repository.Interface
{
    public interface ISupplierRepository : IBaseRepository<Supplier, Database_Context>
    {
    }
}
