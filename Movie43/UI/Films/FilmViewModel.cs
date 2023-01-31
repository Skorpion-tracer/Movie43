using Movie43.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Movie43.UI
{
    public class FilmViewModel : INotifyPropertyChanged
    {
        #region События
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Конструктор
        public FilmViewModel()
        {

        }
        #endregion

        #region Свойства
        public List<byte> Raitings { get; set; } = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public ObservableCollection<Film> Films { get; set; }
        public Film SelectedFilm { get; set; }
        #endregion

        #region Команды

        #endregion
    }
}
