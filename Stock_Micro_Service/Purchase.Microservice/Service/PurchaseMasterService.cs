using System;
using Purchase.Microservice.Model;
using Purchase.Microservice.Repository.Interface;
using Purchase.Microservice.Service.Interface;
using Service.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Common;
using MassTransit;
using EventBus.Common;
using Newtonsoft.Json;

namespace Purchase.Microservice.Service
{
    public class PurchaseMasterService : BaseService<PurchaseMaster>, IPurchaseMasterService
    {
        private IPurchaseMasterRepository purchaseMasterRepository;
        private readonly IPublishEndpoint publishEndpoint;
        public PurchaseMasterService(IPurchaseMasterRepository purchaseMasterRepository, IPublishEndpoint publishEndpoint) : base(purchaseMasterRepository)
        {
            this.purchaseMasterRepository = purchaseMasterRepository;
            this.publishEndpoint = publishEndpoint;
        }
        override
        public async Task<bool> Add(PurchaseMaster entity)
        {
            try
            {
                var invenoty_bus = new List<InventoryBusModel>();

                var Date = DateTime.Today.ToString("yyyyMM");
                var all = purchaseMasterRepository.GetAll(_ => _.VoucherNo.StartsWith(Date)).AsEnumerable().Max(x => x.VoucherNo);
                entity.VoucherNo = GenerateVoucher.Generate(Date, all, 5);
                entity.CreatedAt = DateTime.Now;
                entity.Id = Guid.NewGuid();
                foreach (var item in entity.PurchaseDetails)
                {
                    item.PurchaseMasterId = entity.Id;
                    item.CreatedAt = entity.CreatedAt;
                    item.CreatedBy = entity.CreatedBy;
                    item.Amount = item.UnitPrice * item.Qty;


                    invenoty_bus.Add(new InventoryBusModel()
                    {
                        ProductId = item.ProductId,
                        in_qty = item.Qty,
                        out_qty = 0,
                        remarks = "From Purchase. Voucher No: " + entity.VoucherNo,
                        createdBy = entity.CreatedBy
                    });
                }

                var s = await purchaseMasterRepository.Add(entity);
                if (s)
                {
                    var msg = new InventoryBusMessage()
                    {
                        Name = JsonConvert.SerializeObject(invenoty_bus)
                    };
                    await publishEndpoint.Publish<InventoryBusMessage>(msg);
                }
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        override
        public async Task<bool> Update(PurchaseMaster entity)
        {
            try
            {
                var get_single = await purchaseMasterRepository.Get(entity.Id);
                if (get_single == null)
                {
                    throw new ArgumentNullException("Order not found.");
                }
                get_single.Remarks = entity.Remarks;
                get_single.UpdatedAt = entity.UpdatedAt;
                get_single.UpdatedBy = entity.UpdatedBy;

                var new_details = new List<PurchaseDetails>();
                var deleted_details = new List<PurchaseDetails>();

                foreach (var item in entity.PurchaseDetails)
                {
                    var details_single = entity.PurchaseDetails.Where(_ => _.Id.Equals(item.Id)).FirstOrDefault();
                    if (details_single != null)
                    {
                        item.UnitPrice = details_single.UnitPrice;
                        item.Qty = details_single.Qty;
                        item.ProductId = details_single.ProductId;
                        item.Amount = item.UnitPrice * item.Qty;
                        item.UpdatedAt = entity.UpdatedAt;
                        item.UpdatedBy = entity.UpdatedBy;
                    }
                    else
                    {
                        item.Amount = item.UnitPrice * item.Qty;
                        item.CreatedAt = entity.UpdatedAt ?? DateTime.Now;
                        item.CreatedBy = entity.UpdatedBy ?? get_single.CreatedBy;
                    }
                }
                var s = await purchaseMasterRepository.Add(entity);
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
