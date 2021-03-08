using Authentication.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Common;

namespace Service.Common.Service
{
    public abstract class BaseService<T> : IBaseService<T> 
        where T : BaseEntity 
    {
        protected IBaseRepository<T> baseRepository;

        protected BaseService(IBaseRepository<T> repository)
        {
            baseRepository = repository;
        }
        public Task<bool> Add(T entity)
        {
            try
            {
                return baseRepository.Add(entity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("Cannot insert duplicate key row"))
                {
                    throw new Exception("This data already exist");
                }
                throw ex;
            }
        }

        public Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<long, List<T>>> GetAll(int currentPage, int pageSize, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
