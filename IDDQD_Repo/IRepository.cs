using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;


namespace IDDQD_Repo
{
    public interface IRepository<T> : IDisposable where T : class
    {
        
        T Search(params object[] keyValues);
        
        //the expression stores your LINQ query to create an IQueryable
        T GetSingle(Expression<Func<T, bool>> predicate = null);

        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/
        //https://nejcskofic.github.io/2017/03/20/dynamic-query-expressions-with-entity-framework/
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate = null);

        void Add(T entity);
        void Add(params T[] entities);
        void Add(IEnumerable<T> entities);


        void Delete(T entity);
        void Delete(object id);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);
        
        
        void Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);

    }
}