using System;
using System.Windows.Forms;
using VeriSource.FormGrab.WFD;
using VeriSource.FormGrab.WFD.Scheduler;

namespace WFD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IScheduler scheduler = new Scheduler();
            Application.Run(new WFDForm(scheduler));
        }
    }
}