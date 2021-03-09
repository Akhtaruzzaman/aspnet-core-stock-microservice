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
    public class ProductService : BaseService<Product>, IProductService
    {
        private IProductRepository productRepository;
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            this.productRepository = productRepository;
        }
    }
}
