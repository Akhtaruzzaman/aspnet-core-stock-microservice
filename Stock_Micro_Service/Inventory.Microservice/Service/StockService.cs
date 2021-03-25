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
    public class StockService : BaseService<Stock>, IStockService
    {
        private IStockRepository stockRepository;
        public StockService(IStockRepository stockRepository) : base(stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public async Task<bool> AddRange(List<Stock> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    var last_stock = stockRepository.GetAll(_ => _.ProductId.Equals(item.ProductId)).AsEnumerable().GroupBy(x => x.ProductId).Select(t => new Stock
                    {
                        ProductId = t.FirstOrDefault().ProductId,
                        in_qty = t.Sum(x => x.in_qty),
                        out_qty = t.Sum(x => x.out_qty),
                        balance_qty = t.LastOrDefault().balance_qty
                    }).FirstOrDefault();
                    decimal bl_qty = 0;
                    if (last_stock != null)
                    {
                        bl_qty = last_stock.balance_qty;
                    }
                    item.balance_qty = bl_qty + item.in_qty - item.out_qty;
                    item.CreatedAt = DateTime.Now;
                    item.Id = Guid.NewGuid();
                }
                return await stockRepository.AddMany(entities);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Stock> GetAllStock()
        {
            try
            {
                var query = stockRepository.GetAll().AsEnumerable().GroupBy(x => x.ProductId).Select(t => new Stock
                {
                    ProductId = t.FirstOrDefault().ProductId,
                    in_qty = t.Sum(x => x.in_qty),
                    out_qty = t.Sum(x => x.out_qty),
                    balance_qty = t.LastOrDefault().balance_qty
                });
                return query;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Stock GetStockbyProductId(Guid id)
        {
            try
            {
                var query = stockRepository.GetAll(_ => _.ProductId.Equals(id)).AsEnumerable().GroupBy(x => x.ProductId).Select(t => new Stock
                {
                    ProductId = t.FirstOrDefault().ProductId,
                    in_qty = t.Sum(x => x.in_qty),
                    out_qty = t.Sum(x => x.out_qty),
                    balance_qty = t.LastOrDefault().balance_qty
                }).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
