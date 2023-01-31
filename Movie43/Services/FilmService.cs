using Movie43.Entities;
using Movie43.Repositories;
using Ninject;
using System;
using System.Collections.Generic;

namespace Movie43.Services
{
    public class FilmService : BaseService<Film>
    {
        #region Конструктор
        [Inject]
        public FilmService(IRepository<Film> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Публичные методы
        public override bool Add(Film film)
        {
            return _repository.Add(film);
        }

        public override bool AddRange(IEnumerable<Film> films)
        {
            return _repository.AddRange(films);
        }

        public override bool Delete(Film item)
        {
            return _repository.Delete(item);
        }

        public override bool DeleteRange(IEnumerable<Film> items)
        {
            return _repository.DeleteRange(items);
        }

        public override IEnumerable<Film> GetItems(Predicate<Film> predicate)
        {
            return _repository.GetItems(predicate);
        }

        public override bool Update(Film item)
        {
            return _repository.Update(item);
        }

        public override bool UpdateRange(IEnumerable<Film> items)
        {
            return _repository.UpdateRange(items);
        }
        #endregion
    }
}
