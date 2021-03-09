using Infrastructure.Common.Repository;
using Inventory.Microservice.Model;
using Inventory.Microservice.Model.DBContext;
using Inventory.Microservice.Repository.Interface;

namespace Inventory.Microservice.Repository
{
    public class ProductRepository : BaseRepository<Product, Database_Context>, IProductRepository
    {
        public ProductRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}