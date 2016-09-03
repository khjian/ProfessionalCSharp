using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace FileOperate
{
    public class Test
    {
        public void ForTest()
        {
            File.Copy(@"C:\1.txt", @"D:\copy.txt");

            FileInfo myFile = new FileInfo(@"C:\1.txt");
            StreamReader sr = myFile.OpenText();
            myFile.CopyTo(@"D:\copy.txt");

            StreamReader sr2 = new StreamReader(@"C:\My Documents\ReadMe.txt");

            FileStream fs = new FileStream(@"C:\My Documents\ReadMe.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr3 = new StreamReader(fs);

            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkSofeware = hklm.OpenSubKey("Software");
            RegistryKey hkMicrosoft = hkSofeware.CreateSubKey("MyOwnSoftware");
        }
    }
}
