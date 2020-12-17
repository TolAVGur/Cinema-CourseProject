using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cinema.BLL.Services
{
    public interface IGenericService<T, TKey> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(TKey id);
        T Add(T obj);
        T Update(T obj);
        T Delete(TKey id);
       
    }
}
