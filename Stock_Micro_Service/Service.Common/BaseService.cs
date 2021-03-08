﻿using Infrastructure.Common.Repository;
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
        public async Task<bool> Add(T entity)
        {
            try
            {
                bool result = await repository.Add(entity);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
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
            throw new NotImplementedException();
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

        public async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
