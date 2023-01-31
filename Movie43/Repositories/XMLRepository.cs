using System;
using System.Collections.Generic;

namespace Movie43.Repositories
{
    public class XMLRepository<T> : IRepository<T>
    {
        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetItems(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        private bool Save()
        {
            return true;
        }
    }
}
