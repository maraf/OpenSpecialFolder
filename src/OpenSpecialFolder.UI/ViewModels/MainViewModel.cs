using Neptuo;
using Neptuo.Observables;
using Neptuo.Observables.Collections;
using OpenSpecialFolder.Services;
using OpenSpecialFolder.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OpenSpecialFolder.ViewModels
{
    public class MainViewModel : ObservableModel
    {
        public ObservableCollection<Folder> Folders { get; }
        public OpenFolderCommand Open { get; }
        public CopyToClipBoardAsTextCommand Copy { get; }

        private string normalizedSearchText;
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    RaisePropertyChanged();

                    normalizedSearchText = searchText?.ToLowerInvariant();

                    Search();
                }
            }
        }

        public MainViewModel(IFolderProvider folderProvider)
        {
            Ensure.NotNull(folderProvider, "folderProvider");

            Folders = new ObservableCollection<Folder>(folderProvider.Get().OrderBy(f => f.Name.ToString()));

            Open = new OpenFolderCommand();
            Copy = new CopyToClipBoardAsTextCommand();
        }

        private void Search()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Folders);
            if (view.Filter == null)
                view.Filter = OnFilter;

            view.Refresh();
        }

        private bool OnFilter(object item)
        {
            Folder folder = (Folder)item;
            if (String.IsNullOrEmpty(normalizedSearchText))
                return true;

            if (folder.Name.ToLowerInvariant().Contains(normalizedSearchText))
                return true;

            return false;
        }
    }
}
