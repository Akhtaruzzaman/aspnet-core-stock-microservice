using Microsoft.Extensions.Hosting;
using System;
using Plain.RabbitMQ;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EventBus.Common;
using Sales.Microservice.Service.Interface;

namespace Sales.Microservice.Service
{
    public class StockPublisherService : IHostedService
    {
        private readonly ISubscriber subscriber;
        private readonly ISalesMasterService salesMasterService;
        public StockPublisherService(ISubscriber subscriber, ISalesMasterService salesMasterService)
        {
            this.subscriber = subscriber;
            this.salesMasterService = salesMasterService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            subscriber.Subscribe(Subscribe);
            return Task.CompletedTask;
        }
        private bool Subscribe(string message, IDictionary<string, object> header)
        {
            var response = JsonConvert.DeserializeObject<InventoryBusMessage>(message);
            if (!response.IsSuccess)
            {
                List<InventoryBusModel> list = JsonConvert.DeserializeObject<List<InventoryBusModel>>(response.Name);
                var orderid = list.FirstOrDefault().OrderId;
                salesMasterService.Delete(orderid);
            }
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
