using Neptuo.Observables.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpecialFolder.ViewModels.Commands
{
    public class OpenFolderCommand : Command<FolderViewModel>
    {
        public override bool CanExecute(FolderViewModel folder) => folder != null && Directory.Exists(folder.Path);
        public override void Execute(FolderViewModel folder) => Process.Start(folder.Path);
    }
}
