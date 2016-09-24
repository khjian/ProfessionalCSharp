using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace QuoteClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private QuoteInformation quoteInfo = new QuoteInformation();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = quoteInfo;
        }

        protected async void OnGetQuote(object sender, RoutedEventArgs e)
        {
            const int bufferSize = 1024;
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.Wait;
            quoteInfo.EnableRequest = false;

            string serverName = Properties.Settings.Default.ServerName;
            int port = Properties.Settings.Default.PortNumber;

            var client = new TcpClient();
            NetworkStream stream = null;
            try
            {
                await client.ConnectAsync(serverName, port);
                stream = client.GetStream();
                byte[] buffer = new byte[bufferSize];
                int received = await stream.ReadAsync(buffer, 0, bufferSize);
                if (received <= 0)
                {
                    return;
                }
                quoteInfo.Quote = Encoding.Unicode.GetString(buffer).Trim('\0');
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message, "Error Quote of the day",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }

                if (client.Connected)
                {
                    client.Close();
                }
            }

            this.Cursor = currentCursor;
            quoteInfo.EnableRequest = true;
        }
    }
}
