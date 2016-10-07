using System;
using System.Linq;
using System.ServiceProcess;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ServiceControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ServiceControlWindow : Window
    {
        public ServiceControlWindow()
        {
            InitializeComponent();

            RefreshServiceList();
        }

        protected void RefreshServiceList()
        {
            DataContext = ServiceController.GetServices().
                OrderBy(sc => sc.Status).Select(sc => new ServiceControllerInfo(sc));
        }

        private void OnServiceCommand(object sender, RoutedEventArgs e)
        {
            Cursor oldCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.Wait;
                ButtonState currentButtonState = (ButtonState) (sender as Button).Tag;

                var si = listBoxServices.SelectedItems as ServiceControllerInfo;
                if (currentButtonState == ButtonState.Start)
                {
                    si.Controller.Start();
                    si.Controller.WaitForStatus(ServiceControllerStatus.Running,
                        TimeSpan.FromSeconds(10));
                }
                else if (currentButtonState == ButtonState.Stop)
                {
                    si.Controller.Stop();
                    si.Controller.WaitForStatus(ServiceControllerStatus.Stopped,
                        TimeSpan.FromSeconds(10));
                }
                else if (currentButtonState == ButtonState.Pause)
                {
                    si.Controller.Pause();
                    si.Controller.WaitForStatus(ServiceControllerStatus.Paused,
                        TimeSpan.FromSeconds(10));
                }
                else if (currentButtonState == ButtonState.Continue)
                {
                    si.Controller.Pause();
                    si.Controller.WaitForStatus(ServiceControllerStatus.Running,
                        TimeSpan.FromSeconds(10));
                }
                int index = listBoxServices.SelectedIndex;
                RefreshServiceList();
                listBoxServices.SelectedIndex = index;
            }
            catch (System.ServiceProcess.TimeoutException ex)
            {
                MessageBox.Show(ex.Message, "Timeout Service Controller",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(String.Format("{0} {1}", ex.Message,
                        ex.InnerException != null
                            ? ex.InnerException.Message
                            : string.Empty), "Error Service Controller",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                this.Cursor = oldCursor;
            }
        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            RefreshServiceList();
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
