using Infrastructure.Common.Repository;
using Inventory.Microservice.Model;
using Inventory.Microservice.Model.DBContext;
using Inventory.Microservice.Repository.Interface;

namespace Inventory.Microservice.Repository
{
    public class StockRepository : BaseRepository<Stock, Database_Context>, IStockRepository
    {
        public StockRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}