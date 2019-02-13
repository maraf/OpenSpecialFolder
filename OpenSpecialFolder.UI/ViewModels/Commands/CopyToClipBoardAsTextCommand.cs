using Neptuo.Observables.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenSpecialFolder.ViewModels.Commands
{
    public class CopyToClipBoardAsTextCommand : Command<object>
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Clipboard.SetText(parameter?.ToString());
    }
}
