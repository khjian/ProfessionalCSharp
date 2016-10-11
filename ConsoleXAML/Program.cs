using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ConsoleXAML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var b = new Button()
            {
                Content = "Click Me!"
            };
            var w = new Window()
            {
                Title = "Code Demo",
                Content = b
            };

            var app = new Application();
            app.Run(w);
        }
    }
}
