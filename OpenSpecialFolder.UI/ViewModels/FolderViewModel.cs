using Neptuo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpecialFolder.ViewModels
{
    public class FolderViewModel
    {
        public Environment.SpecialFolder Name { get; }
        public string Path { get; }

        public FolderViewModel(Environment.SpecialFolder name, string path)
        {
            Ensure.NotNull(name, "name");
            Ensure.NotNull(path, "path");
            Name = name;
            Path = path;
        }
    }
}
