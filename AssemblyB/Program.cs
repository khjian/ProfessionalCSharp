using System;
using System.Reflection;

namespace AssemblyB
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine(currentDomain.FriendlyName);
            AppDomain seconDomain = AppDomain.CreateDomain("New AppDomain");
            //seconDomain.ExecuteAssembly("AssemblyA.exe");
            seconDomain.CreateInstance("AssemblyA", "AssemblyA.Demo", true,BindingFlags.CreateInstance, null,new object[] {7,3},null,null );
        }
    }
}
