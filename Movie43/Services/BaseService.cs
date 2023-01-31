using Movie43.Repositories;
using System;
using System.Collections.Generic;

namespace Movie43.Services
{
    public abstract class BaseService<T> : IRepository<T>
    {
        #region Поля
        protected IRepository<T> _repository;
        #endregion

        #region Абстрактные методы
        public abstract bool Add(T item);
        public abstract bool AddRange(IEnumerable<T> items);
        public abstract bool Delete(T item);
        public abstract bool DeleteRange(IEnumerable<T> items);
        public abstract IEnumerable<T> GetItems(Predicate<T> predicate);
        public abstract bool Update(T item);
        public abstract bool UpdateRange(IEnumerable<T> items);
        #endregion
    }
}
