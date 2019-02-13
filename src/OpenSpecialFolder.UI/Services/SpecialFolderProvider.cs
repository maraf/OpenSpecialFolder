using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpecialFolder.Services
{
    public class SpecialFolderProvider : IFolderProvider
    {
        public IEnumerable<Folder> Get()
        {
            foreach (int folderValue in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                Environment.SpecialFolder folder = (Environment.SpecialFolder)folderValue;
                yield return new Folder(folder.ToString(), Environment.GetFolderPath(folder));
            }
        }
    }
}
