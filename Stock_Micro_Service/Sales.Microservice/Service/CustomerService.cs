using Sales.Microservice.Model;
using Sales.Microservice.Repository.Interface;
using Sales.Microservice.Service.Interface;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Microservice.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            this.customerRepository = customerRepository;
        }

    }
}
