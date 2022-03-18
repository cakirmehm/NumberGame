using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace Sayı_Oyunu_2014
{

  

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //F_Splash splash = new F_Splash();
            //Application.Run(splash);


            bool mutexCreated = true;
            using (Mutex mutex = new Mutex(true, "SayiOyunu2014", out mutexCreated))
            {
                if (mutexCreated)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    F_Splash splash = new F_Splash();
                    Application.Run(splash);
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process pro in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (pro.Id != current.Id)
                        {
                            MessageBox.Show("Yalnızca bir adet oyun penceresi açılabilir.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }


            }
        }
    }
}