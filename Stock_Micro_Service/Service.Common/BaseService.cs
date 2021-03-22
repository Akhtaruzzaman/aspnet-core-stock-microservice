using Infrastructure.Common.Repository;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public class BaseService<T> where T : BaseEntity
    {
        dynamic repository;
        public BaseService(dynamic repository)
        {
            this.repository = repository;
        }
        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.Id = Guid.NewGuid();
                bool result = await repository.Add(entity);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await repository.Get(id);
                bool result = await repository.Delete(entity);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Get(Guid id)
        {
            try
            {
                T result = await repository.Get(id);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var result = repository.GetAll();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                entity.UpdatedAt = DateTime.Now;
                bool result = await repository.Update(entity);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
