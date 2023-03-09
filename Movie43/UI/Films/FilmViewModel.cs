using Movie43.Entities;
using Movie43.Enums;
using Movie43.Models;
using Movie43.Models.Helper;
using Ninject;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Movie43.UI
{
    public class FilmViewModel : INotifyPropertyChanged
    {
        #region Поля
        private FilmModel _filmModel;
        #endregion

        #region События
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Конструктор
        [Inject]
        public FilmViewModel(FilmModel filmModel)
        {
            _filmModel = filmModel;

            UpdateFilms();

            AddFilmCommand = new UICommand(AddFilm);
            OpenPanelEditCommand = new UICommand(OpenPanelEdit);
        }
        #endregion

        #region Свойства
        public List<byte> Raitings { get; set; } = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public ObservableCollection<Film> Films { get; set; }
        public Film SelectedFilm { get; set; }
        public ActionItem ActionItem { get; set; }
        public bool IsOpenPanelEdit { get; set; }
        public string SelectedText { get; set; }
        #endregion

        #region Команды
        public ICommand AddFilmCommand { get; set; }
        public ICommand OpenPanelEditCommand { get; set; }
        #endregion

        #region Приватные методы
        private void OpenPanelEdit(object param)
        {
            IsOpenPanelEdit = !IsOpenPanelEdit;
        }

        private void AddFilm(object param)
        {
            Task.Factory.StartNew(Add);
        }

        private async Task Add()
        {
            await Task.Run(() =>
            {
                if (SelectedFilm != null)
                {
                    if (_filmModel.Add(SelectedFilm, out string info))
                    {
                        UpdateFilms();
                        MessageBox.Show(info, "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(info, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });
        }

        private void UpdateFilms()
        {
            Films = new(_filmModel.Films);
        }
        #endregion
    }
}
