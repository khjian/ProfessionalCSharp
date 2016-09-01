using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperate
{
    public class Test
    {
        public void ForTest()
        { 
            File.Copy(@"C:\1.txt",@"D:\copy.txt");

            FileInfo myFile = new FileInfo(@"C:\1.txt");
            myFile.CopyTo(@"D:\copy.txt");

            Console.WriteLine(Path.Combine(@"C:\My Documents","ReadMe.txt"));
        }
    }
}
