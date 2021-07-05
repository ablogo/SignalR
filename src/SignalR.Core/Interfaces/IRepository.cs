using SignalR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task Add(T entity);
        
        Task Add(IEnumerable<T> entities);
        
        Task Edit(T entity);
        
        Task Delete(object id);
        
        Task Delete(T entity);
    }
}
