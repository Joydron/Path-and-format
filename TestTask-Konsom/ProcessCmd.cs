using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingCmd
{
    internal class ProcessCmd
    {
        public static string Cmd (string pathDisk)
        {
            // Запускаем cmd
            Process pCmd = new Process();
            pCmd.StartInfo.CreateNoWindow = false;
            pCmd.StartInfo.UseShellExecute = false;
            pCmd.StartInfo.RedirectStandardOutput = true;
            pCmd.StartInfo.FileName = "cmd.exe";
            pCmd.StartInfo.Arguments = "/C" + pathDisk;
            pCmd.Start();

            // Результат поиска вносим в переменную
            string output = pCmd.StandardOutput.ReadToEnd();
            pCmd.WaitForExit();
            return output;
        }
        
    }
}
