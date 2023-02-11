using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeverLose
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AsemblyResolve);

            Process[] processes = Process.GetProcessesByName("csgo");

            if (processes.Length == 0)
            {
                // Game isnt running
                // No problem
             
                Application.Run(new NL());

            }
            else
            {
                // Game is running
                // Lets close the game and then initialize
                foreach (var process in Process.GetProcessesByName("csgo"))
                {
                    process.Kill();
                    Application.Run(new NL());
                }

               

            }
      

        }
        static System.Reflection.Assembly CurrentDomain_AsemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(LOAD).Namespace + ".Guna.UI2.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return System.Reflection.Assembly.Load(assemblyData);
            }
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(NL).Namespace + ".Guna.UI2.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return System.Reflection.Assembly.Load(assemblyData);
            }
        }
    }
}
