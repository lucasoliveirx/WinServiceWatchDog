using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinService_WatchDog
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static void Main()
        {
            var service = new Service1();

            service.InitializeSelfHost();

            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
