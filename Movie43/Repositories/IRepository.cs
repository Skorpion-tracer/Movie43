using System;
using System.Collections.Generic;

namespace Movie43.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T item);
        bool AddRange(IEnumerable<T> items);
        bool Delete(T item);
        bool DeleteRange(IEnumerable<T> items);
        bool Update(T item);
        bool UpdateRange(IEnumerable<T> items);
        IEnumerable<T> GetItems(Predicate<T> predicate);
    }
}
