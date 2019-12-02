using System;
using System.ServiceModel;
using System.ServiceProcess;
using DirectoryFileCount.Server.DirectoryFileCountSimulatorServerImplementation;

namespace DirectoryFileCount.Server.DirectoryFileCountWCFServer
{
    partial class DirectoryFileCountWCFService : ServiceBase
    {
        internal const string CurrentServiceName = "DirectoryFileCountService";
        internal const string CurrentServiceDisplayName = "DirectoryFileCount Service";
        internal const string CurrentServiceSource = "DirectoryFileCountSource";
        internal const string CurrentServiceLogName = "DirectoryFileCountLogName";
        internal const string CurrentServiceDescription = "DirectoryFileCount";
        private ServiceHost _serviceHost = null;

        public DirectoryFileCountWCFService()
        {
            InitializeComponent();
            ServiceName = CurrentServiceName;
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        protected override void OnStart(string[] args)
        {
#if DEBUG
            RequestAdditionalTime(120 * 1000);
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(1000);
            //}
#endif
            _serviceHost?.Close();
            try
            {
                _serviceHost = new ServiceHost(typeof(DirectoryFileCountSimulatorImpl));
                _serviceHost.Open();
            }
            catch (Exception ex)
            {
                //TODO implement Logging
                throw;
            }
        }

        protected override void OnStop()
        {
            RequestAdditionalTime(120 * 1000);
            try
            {
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                //TODO add Logging
            }
        }
    }
}
