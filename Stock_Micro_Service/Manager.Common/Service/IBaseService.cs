using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common.Service
{
    public interface IBaseService<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Task<Tuple<long, List<T>>> GetAll(int currentPage, int pageSize, T entity);
    }
}
