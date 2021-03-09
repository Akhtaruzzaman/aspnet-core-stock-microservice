using Inventory.Microservice.Model;
using Inventory.Microservice.Repository.Interface;
using Inventory.Microservice.Service.Interface;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Microservice.Service
{
    public class StockService: BaseService<Stock>, IStockService
    {
        private IStockRepository stockRepository;
        public StockService(IStockRepository stockRepository) : base(stockRepository)
        {
            this.stockRepository = stockRepository;
        }
    }
}
