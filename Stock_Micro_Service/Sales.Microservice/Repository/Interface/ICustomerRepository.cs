using Infrastructure.Common.Repository;
using Sales.Microservice.Model;
using Sales.Microservice.Model.DBContext;

namespace Sales.Microservice.Repository.Interface
{
    public interface ICustomerRepository : IBaseRepository<Customer, Database_Context>
    {
    }
}
