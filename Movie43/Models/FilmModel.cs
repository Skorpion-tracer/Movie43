using Movie43.Entities;
using Movie43.Repositories;
using Movie43.Services;
using Ninject;
using System;
using System.Collections.Generic;

namespace Movie43.Models
{
    public class FilmModel : IRepository<Film>
    {
        #region Поля
        private FilmService _service;
        #endregion

        #region Конструктор
        [Inject]
        public FilmModel(FilmService service)
        {
            _service = service;
        }
        #endregion

        #region Публичные методы
        public bool Add(Film item)
        {
            throw new NotImplementedException();
        }

        public bool AddRange(IEnumerable<Film> items)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Film item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRange(IEnumerable<Film> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Film> GetItems(Predicate<Film> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Film item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(IEnumerable<Film> items)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
