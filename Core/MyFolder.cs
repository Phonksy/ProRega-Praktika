using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Serializable]
    public class MyFolder
    {
        public string FolderName { get; set; }
        public string Path { get; set; }

        public MyFolder(string path)
        {
            this.Path = path;
            this.FolderName = System.IO.Path.GetFileName(path);
        }

        public MyFolder() { }
    }
}
