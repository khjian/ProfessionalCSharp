using System.ServiceProcess;

namespace ServiceControl
{
    public class ServiceControllerInfo
    {
        private readonly ServiceController controller;

        public ServiceControllerInfo(ServiceController controller)
        {
            this.controller = controller;
        }

        public ServiceController Controller => controller;

        public string ServiceTypeName
        {
            get
            {
                ServiceType type = controller.ServiceType;
                string serviceTypeName = "";
                if ((type & ServiceType.InteractiveProcess) != 0)
                {
                    serviceTypeName = "Interactive ";
                    type -= ServiceType.InteractiveProcess;
                }

                switch (type)
                {
                    case ServiceType.Adapter:
                        serviceTypeName += "Adapter";
                        break;

                    case ServiceType.FileSystemDriver:
                    case ServiceType.KernelDriver:
                    case ServiceType.RecognizerDriver:
                        serviceTypeName += "Driver";
                        break;

                    case ServiceType.Win32OwnProcess:
                        serviceTypeName += "Win32 Service Process";
                        break;

                    case ServiceType.Win32ShareProcess:
                        serviceTypeName += "Win32 Service Process";
                        break;

                    default:
                        serviceTypeName += "unknown type " + type.ToString();
                        break;
                }
                return serviceTypeName;
            }
        }

        public string ServiceStatusName
        {
            get
            {
                switch (controller.Status)
                {
                    case ServiceControllerStatus.ContinuePending:
                        return "Continue Pending";
                    case ServiceControllerStatus.Paused:
                        return "Paused";
                    case ServiceControllerStatus.PausePending:
                        return "Pause Pending";
                    case ServiceControllerStatus.Running:
                        return "Running";
                    case ServiceControllerStatus.StartPending:
                        return "Start Pending";
                    case ServiceControllerStatus.Stopped:
                        return "Stopped";
                    case ServiceControllerStatus.StopPending:
                        return "Stop Pending";
                    default:
                        return "Unknown status";
                }
            }
        }

        public string DisplayName => controller.DisplayName;

        public string ServiceName => controller.ServiceName;

        public bool EnableStart => controller.Status == ServiceControllerStatus.Stopped;

        public bool EnableStop => controller.Status == ServiceControllerStatus.Running;

        public bool EnablePause => controller.Status == ServiceControllerStatus.Running &&
                                   controller.CanPauseAndContinue;

        public bool EnableContinue => controller.Status == ServiceControllerStatus.Paused;
    }
}
