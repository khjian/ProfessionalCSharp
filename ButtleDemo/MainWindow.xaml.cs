using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ButtleDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> messages = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = messages;
        }

        private void AddMessage(string message, object sender, RoutedEventArgs e)
        {
            messages.Add(
                $"{message}," +
                $"sender:{(sender as FrameworkElement).Name};" +
                $"source:{(e.Source as FrameworkElement).Name};" +
                $"original source:{(e.OriginalSource as FrameworkElement).Name}");
        }

        private void OnOuterButtonClick(object sender, RoutedEventArgs e)
        {
            AddMessage("最外层单击", sender, e);
        }

        private void OnButton2(object sender, RoutedEventArgs e)
        {
            AddMessage("Button2单击",sender,e);
            e.Source = sender;
        }

        private void OnInner1(object sender, RoutedEventArgs e)
        {
            AddMessage("Inner 1 Click!",sender,e);
        }

        private void OnInner2(object sender, RoutedEventArgs e)
        {
            AddMessage("Inner 2 Click!", sender, e);
            e.Handled = true;
        }
    }
}
