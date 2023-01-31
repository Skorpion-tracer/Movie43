using System.Windows.Controls;

namespace Movie43.UI
{
    /// <summary>
    /// Логика взаимодействия для FilmScreen.xaml
    /// </summary>
    public partial class FilmScreen : UserControl
    {
        public FilmScreen()
        {
            InitializeComponent();

            FilmViewModel filmViewModel = new FilmViewModel();
            DataContext = filmViewModel;
        }
    }
}
