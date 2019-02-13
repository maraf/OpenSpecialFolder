using Neptuo.Observables.Commands;
using OpenSpecialFolder.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpecialFolder.ViewModels.Commands
{
    public class OpenFolderCommand : Command<Folder>
    {
        public override bool CanExecute(Folder folder) => folder != null && Directory.Exists(folder.Path);
        public override void Execute(Folder folder) => Process.Start(folder.Path);
    }
}
