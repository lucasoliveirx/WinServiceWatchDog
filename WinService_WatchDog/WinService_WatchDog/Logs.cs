using System;
using System.IO;

namespace WinService_WatchDog
{
    public class Logs
    {
        public static void RegisterLog(string message, string logFilePath)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine(DateTime.Now.ToString() + " - " + message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao registrar log: " + ex.Message);
            }
        }
    }
}
