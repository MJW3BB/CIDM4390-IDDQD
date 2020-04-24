using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace IDDQD_Repo
{
    public interface IRepositoryAsync<T> where T : class
    {
        //T Search(params object[] keyValues);
        
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate = null);

        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/
        //https://nejcskofic.github.io/2017/03/20/dynamic-query-expressions-with-entity-framework/
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);

        ValueTask<EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        Task AddAsync(params T[] entities);
        Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));

        // Task Delete(T entity, CancellationToken cancellationToken = default(CancellationToken));
        // Task Delete(object id);
        // Task Delete(params T[] entities);
        // Task Delete(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
        
        void UpdateAsync(T entity);
        // Task UpdateAsync(params T[] entities);
        // Task UpdateAsync(IEnumerable<T> entities);        
    }
}