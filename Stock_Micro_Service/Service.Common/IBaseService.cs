using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IBaseService<T>
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
