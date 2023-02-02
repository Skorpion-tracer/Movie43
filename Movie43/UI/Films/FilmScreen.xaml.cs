using Movie43.DI;
using System.ComponentModel;
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

            if (DesignerProperties.GetIsInDesignMode(this)) return;

            DataContext = Locator.Resolve<FilmViewModel>();
        }
    }
}
