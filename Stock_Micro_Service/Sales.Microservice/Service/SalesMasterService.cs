using System;
using Sales.Microservice.Model;
using Sales.Microservice.Repository.Interface;
using Sales.Microservice.Service.Interface;
using Service.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Common;

namespace Sales.Microservice.Service
{
    public class SalesMasterService : BaseService<SalesMaster>, ISalesMasterService
    {
        private ISalesMasterRepository salesMasterRepository;
        public SalesMasterService(ISalesMasterRepository salesMasterRepository) : base(salesMasterRepository)
        {
            this.salesMasterRepository = salesMasterRepository;
        }
        override
        public async Task<bool> Add(SalesMaster entity)
        {
            try
            {
                var Date = DateTime.Today.ToString("yyyyMM");
                var all = salesMasterRepository.GetAll(_ => _.VoucherNo.StartsWith(Date)).AsEnumerable().Max(x => x.VoucherNo);
                entity.VoucherNo = GenerateVoucher.Generate(Date, all, 5);

                foreach (var item in entity.SalesDetails)
                {
                    item.CreatedAt = entity.CreatedAt;
                    item.CreatedBy = entity.CreatedBy;
                    item.Amount = item.UnitPrice * item.Qty;
                }

                var s = await salesMasterRepository.Add(entity);
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        override
        public async Task<bool> Update(SalesMaster entity)
        {
            try
            {
                var get_single = await salesMasterRepository.Get(entity.Id);
                if (get_single==null)
                {
                    throw new ArgumentNullException("Order not found.");
                }
                get_single.Remarks = entity.Remarks;
                get_single.UpdatedAt = entity.UpdatedAt;
                get_single.UpdatedBy = entity.UpdatedBy;

                var new_details = new List<SalesDetails>();
                var deleted_details = new List<SalesDetails>();

                foreach (var item in entity.SalesDetails)
                {
                    var details_single = entity.SalesDetails.Where(_ => _.Id.Equals(item.Id)).FirstOrDefault();
                    if (details_single != null)
                    {
                        item.UnitPrice = details_single.UnitPrice;
                        item.Qty = details_single.Qty;
                        item.ProductId = details_single.ProductId;
                        item.Amount = item.UnitPrice * item.Qty;
                    }
                    else
                    {

                    }
                   
                }

                var s = await salesMasterRepository.Add(entity);
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
