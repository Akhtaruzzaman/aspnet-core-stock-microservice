using Microsoft.EntityFrameworkCore;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Repository
{
    public interface IBaseRepository<T, C> : IDisposable
        where T : BaseEntity
        where C : DbContext
    {
        Task<bool> Add(T entity);
        Task<bool> AddMany(List<T> entity);
        Task<bool> Update(T entity);
        Task<bool> UpdateMany(List<T> entity);

        /// <summary>
        /// This method for permanent delation of those row that
        /// are not used in any transaction
        /// </summary>
        /// <param name="id"></param>
        Task<bool> Delete(Guid id);
        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> expression);
        Task<T> Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Get any by expression first or default
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> GetAny(Expression<Func<T, bool>> expression);
        Guid GetId();
    }
}
