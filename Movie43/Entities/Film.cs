using Movie43.Enums;
using System;
using System.ComponentModel;

namespace Movie43.Entities
{
    public class Film : INotifyPropertyChanged
    {
        #region Поля
        private readonly int _minRating;
        private readonly int _maxRating = 10;
        private int? _waitingRating;
        #endregion

        #region События
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Свойства
        /// <summary>
        /// Название фильма
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Жанр фильма
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// Рейтинг ожидания
        /// </summary>
        public int? WaitingRating
        {
            get => _waitingRating;
            set
            {
                if (value < _minRating)
                {
                    value = _minRating;
                }

                if (value > _maxRating)
                {
                    value = _maxRating;
                }

                _waitingRating = value;
            }
        }
        /// <summary>
        /// Дата выхода фильма
        /// </summary>
        public DateTime DateOut { get; set; } = DateTime.Now;
        /// <summary>
        /// Итоговая оценка
        /// </summary>
        public Verdict Verdict { get; set; } = Verdict.FORONETIME;
        #endregion
    }
}
