using Neptuo.Observables;
using Neptuo.Observables.Collections;
using OpenSpecialFolder.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenSpecialFolder.ViewModels
{
    public class MainViewModel : ObservableModel
    {
        public ObservableCollection<FolderViewModel> Folders { get; }
        public OpenFolderCommand Open { get; }
        public CopyToClipBoardAsTextCommand Copy { get; }

        public MainViewModel()
        {
            Folders = new ObservableCollection<FolderViewModel>();

            List<FolderViewModel> folders = new List<FolderViewModel>();
            foreach (int folderValue in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                Environment.SpecialFolder folder = (Environment.SpecialFolder)folderValue;
                folders.Add(new FolderViewModel(folder, Environment.GetFolderPath(folder)));
            }

            Folders.AddRange(folders.OrderBy(f => f.Name.ToString()));

            Open = new OpenFolderCommand();
            Copy = new CopyToClipBoardAsTextCommand();
        }
    }
}
