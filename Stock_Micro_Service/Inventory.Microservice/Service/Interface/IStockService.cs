using Inventory.Microservice.Model;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Microservice.Service.Interface
{
    public interface IStockService : IBaseService<Stock>
    {
        IEnumerable<Stock> GetAllStock();
        Stock GetStockbyProductId(Guid id);
    }
}
