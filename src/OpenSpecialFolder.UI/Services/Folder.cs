using Neptuo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpecialFolder.Services
{
    public class Folder
    {
        public string Name { get; }
        public string Path { get; }

        public Folder(string name, string path)
        {
            Ensure.NotNull(name, "name");
            Ensure.NotNull(path, "path");
            Name = name;
            Path = path;
        }
    }
}
