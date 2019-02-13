using OpenSpecialFolder.ViewModels;
using OpenSpecialFolder.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OpenSpecialFolder
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainViewModel viewModel = new MainViewModel();

            MainWindow view = new MainWindow();
            view.DataContext = viewModel;

            view.Show();
        }
    }
}
