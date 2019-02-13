using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpecialFolder.Services
{
    public interface IFolderProvider
    {
        IEnumerable<Folder> Get();
    }
}
