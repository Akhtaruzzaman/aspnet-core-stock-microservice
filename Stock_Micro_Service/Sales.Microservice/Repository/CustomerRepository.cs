using Infrastructure.Common.Repository;
using Sales.Microservice.Model;
using Sales.Microservice.Model.DBContext;
using Sales.Microservice.Repository.Interface;

namespace Sales.Microservice.Repository
{
    public class CustomerRepository : BaseRepository<Customer, Database_Context>, ICustomerRepository
    {
        public CustomerRepository(Database_Context database_Context) : base(database_Context)
        {

        }
    }
}