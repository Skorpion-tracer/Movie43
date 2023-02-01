using Movie43.Entities;
using Movie43.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie43.Models
{
    public class FilmModel
    {
        #region Поля
        private FilmService _service;
        #endregion

        #region Конструктор
        [Inject]
        public FilmModel(FilmService service)
        {
            _service = service;

            LoadFilms();
        }
        #endregion

        #region Свойства
        public List<Film> Films { get; set; }
        #endregion

        #region Публичные методы
        public bool Add(Film item, out string info)
        {
            info = string.Empty;

            if (Films.FirstOrDefault(e => e.Name == item.Name) != null)
            {
                info = "Фильм с таким названием уже есть в списке!";
                return false;
            }

            if (_service.Add(item))
            {
                Films.Add(item);
                info = "Фильм успешно добавлен.";
            }

            info = "Возникла ошибка добавления!";
            return false;
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
            return _service.GetItems(predicate);
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

        #region Приватные методы
        private void LoadFilms()
        {
            Films = new(GetItems(e => !string.IsNullOrEmpty(e.Name)));
        }
        #endregion
    }
}
