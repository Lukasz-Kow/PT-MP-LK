using Presentations.ViewModel;
using System.Data.Linq;
using System.Windows;

namespace Presentations
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()

            };

        MainWindow.Show();
        base.OnStartup(e);
    }


    }
}
