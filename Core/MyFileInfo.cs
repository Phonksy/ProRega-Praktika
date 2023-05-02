using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Serializable]
    public class MyFileInfo
    {
        public string FileName {  get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

        public MyFileInfo(string path)
        {
            this.Path = path;
            this.FileName = System.IO.Path.GetFileName(path);
            this.Extension = System.IO.Path.GetExtension(path);
        }

        public MyFileInfo(string path, string filename, string extension) 
        {
            this.Path = path;
            this.FileName = filename;
            this.Extension = extension;
        }

        public MyFileInfo() { }
    }
}
