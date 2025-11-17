using System;
using System.Diagnostics;
using System.Timers;

namespace WinService_WatchDog
{
    public static class MonitorWinServices
    {
        private static string logTxtFilePath = @"C:\Log\WatchDog_Logs\WatchDog_Logs.txt";


        public static void MonitorProcesses(object sender, ElapsedEventArgs e)
        {
            var monitoredProcesses = new (string Name, string FilePatch)[]
               {
                    //("NameService1", @"C:\App\NameService1.exe"),
                    //("NameService2", @"C:\App\NameService2.exe"),
                    //("NameService3", @"C:\App\NameService3.exe"),
               };

            foreach (var proc in monitoredProcesses)
            {
                Process[] processes = Process.GetProcessesByName(proc.Name);

                if (processes.Length == 0)
                {
                    Logs.RegisterLog($"{proc.Name} não está executando. Tentando reiniciar...", logTxtFilePath);

                    try
                    {
                        Logs.RegisterLog($"Reiniciando {proc.Name}...", logTxtFilePath);

                        Process.Start($"{proc.FilePatch}");

                        Logs.RegisterLog($"{proc.Name} reinciado com sucesso!", logTxtFilePath);
                    }

                    catch (Exception ex)
                    {
                        Logs.RegisterLog($"Erro ao reiniciar processo. Detalhe do erro: {ex.Message}", logTxtFilePath);
                    }
                }
            }
        }
    }
}

