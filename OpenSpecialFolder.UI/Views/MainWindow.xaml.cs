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

            Title += $" (v{VersionInfo.Version})";
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            SearchText.Focus();
        }

        private void SearchText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                ListView.SelectedIndex = 0;
                ListViewItem item = (ListViewItem)ListView.ItemContainerGenerator.ContainerFromIndex(0);
                if (item != null)
                {
                    item.Focus();
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.Escape)
            {
                SearchText.Text = null;
                e.Handled = true;
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListView.SelectedItem is FolderViewModel folder && ViewModel.Open.CanExecute(folder))
                ViewModel.Open.Execute(folder);
        }

        private void ListView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((ListView.SelectedIndex == 0 && e.Key == Key.Up) || e.Key == Key.Escape)
            {
                SearchText.Focus();
                e.Handled = true;
            }
        }
    }
}
