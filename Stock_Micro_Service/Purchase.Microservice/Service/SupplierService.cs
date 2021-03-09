using Purchase.Microservice.Model;
using Purchase.Microservice.Repository.Interface;
using Purchase.Microservice.Service.Interface;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase.Microservice.Service
{
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        private ISupplierRepository supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository) : base(supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

    }
}
