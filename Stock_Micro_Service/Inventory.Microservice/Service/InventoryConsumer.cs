using EventBus.Common;
using Inventory.Microservice.Model;
using Inventory.Microservice.Service.Interface;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Inventory.Microservice.Service
{
    public class InventoryConsumer : IConsumer<InventoryBusMessage>
    {
        public IStockService stockService;
        public InventoryConsumer(IStockService stockService)
        {
            this.stockService = stockService;
        }
        public async Task Consume(ConsumeContext<InventoryBusMessage> context)
        {
            var eb_model = JsonConvert.DeserializeObject<List<InventoryBusModel>>(context.Message.Name);
            var stock = new List<Stock>();
            foreach (var item in eb_model)
            {
                stock.Add(new Stock()
                {
                    ProductId = item.ProductId,
                    in_qty = item.in_qty,
                    out_qty = item.out_qty,
                    remarks = item.remarks,
                    CreatedBy = item.createdBy,
                });
            }
            var res = await stockService.AddRange(stock);
            if (res)
                _ = Console.Out.WriteLineAsync("stock added");
            else
                _ = Console.Out.WriteLineAsync("stock added failed");
        }
    }
}
