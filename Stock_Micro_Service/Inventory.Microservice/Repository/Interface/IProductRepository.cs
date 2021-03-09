using Infrastructure.Common.Repository;
using Inventory.Microservice.Model;
using Inventory.Microservice.Model.DBContext;

namespace Inventory.Microservice.Repository.Interface
{
    public interface IProductRepository : IBaseRepository<Product, Database_Context>
    {
    }
}
