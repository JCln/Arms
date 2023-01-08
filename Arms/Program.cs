using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Arms.Forms;

namespace Arms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //SplashForm.ShowSplashScreen();
            //MasterForm masterForm = new MasterForm();
            //SplashForm.CloseForm();
            //Application.Run(masterForm);

            SplashForm splashForm = new SplashForm();
            Application.Run(splashForm);
        }
    }
}
