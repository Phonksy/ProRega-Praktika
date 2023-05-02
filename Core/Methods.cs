using Microsoft.Win32;
using System;
using System.Security.Policy;
using System.Windows.Media.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Core
{
    public class Methods
    {
        public static List<MyFileInfo> OpenFolder(ref string path)
        {
            List<MyFileInfo> fileInfos = new List<MyFileInfo> ();           

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                path = dialog.SelectedPath;

                if (result == DialogResult.OK && Directory.Exists(path))
                {                   
                    var fileNames = Directory.EnumerateFiles(path, "*.*" , SearchOption.AllDirectories);
                  
                    var filteredFilePaths = fileNames.Where(f => f.Contains(".jpg") || f.Contains(".png"));

                    foreach(var item in filteredFilePaths)
                    {                       
                        fileInfos.Add(new MyFileInfo(item));
                    }
                }
                else
                {
                    dialog.Dispose();
                }
            }

            return fileInfos;
        } 
        
        public static BitmapImage OpenImage(string path)
        {
            if (File.Exists(path))
            {
                BitmapImage image = new BitmapImage(new Uri(path));

                return image;
            }
            else 
            {
                return null;
            }
        }
    }
}
