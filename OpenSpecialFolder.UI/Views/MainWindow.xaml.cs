using OpenSpecialFolder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenSpecialFolder.Views
{
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel => (MainViewModel)DataContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListView.SelectedItem is FolderViewModel folder && ViewModel.Open.CanExecute(folder))
                ViewModel.Open.Execute(folder);
        }
    }
}
