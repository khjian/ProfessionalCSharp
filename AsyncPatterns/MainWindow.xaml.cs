using AsyncLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AsyncPatterns
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private SearchInfo searchInfo;
        public MainWindow()
        {
            InitializeComponent();
            searchInfo = new SearchInfo();
            this.DataContext = searchInfo;
        }

        private void OnClear(object sender, RoutedEventArgs e)
        {

        }

        private void OnSearchSync(object sender, RoutedEventArgs e)
        {
            foreach (var req in GetSearchRequests())
            {
                var client = new WebClient();
                client.Credentials = req.Credentials;
                string resp = client.DownloadString(req.Url);
                IEnumerable<SearchItemResult> images = req.Parse(resp);
                foreach (var image in images)
                {
                    searchInfo.List.Add(image);
                }
            }
        }

        private void OnSeachAsyncPattern(object sender, RoutedEventArgs e)
        {
            Func<string, ICredentials, string> downloadString = (address, cred) =>
            {
                var client = new WebClient();
                client.Credentials = cred;
                return client.DownloadString(address);
            };
            Action<SearchItemResult> addItem = item => searchInfo.List.Add(item);
            foreach (var req in GetSearchRequests())
            {
                downloadString.BeginInvoke(req.Url, req.Credentials, ar =>
                {
                    string resp = downloadString.EndInvoke(ar);
                    IEnumerable<SearchItemResult> images = req.Parse(resp);
                    foreach (var image in images)
                    {
                        this.Dispatcher.Invoke(addItem, image);
                    }
                }, null);
            }
        }

        private void OnAsyncEventPattern(object sender, RoutedEventArgs e)
        {

        }

        private void OnTaskBasedAsyncPattern(object sender, RoutedEventArgs e)
        {

        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {

        }

        private IEnumerable<IImageRequest> GetSearchRequests()
        {
            return new List<IImageRequest>
            {
                new BingRequest() {SearchTerm = searchInfo.SearchTerm},
                //new FlickrRequest() {SearchTerm = searchInfo.SearchTerm}
            };
        }
    }
}
