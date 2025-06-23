using System.ServiceProcess;
using System.Timers;


namespace WinService_WatchDog
{
    public partial class Service1 : ServiceBase
    {
        private static Timer _timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            InitializeSelfHost();
        }

        protected override void OnStop()
        {
            _timer.Stop();
        }

        internal void InitializeSelfHost()
        {
            _timer = new Timer(30000);

            _timer.Elapsed += MonitorWinServices.MonitorProcesses;

            _timer.Start();
        }
    }
}
