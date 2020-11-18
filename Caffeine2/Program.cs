using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace Caffeine2
{
    class Program
    {
        public static CaffeineEngine engine;
        public static NotifyIcon NotifyIcon;
        public static ContextMenuStrip Cxt;

        static void Main(string[] args)
        {
            engine = new CaffeineEngine(); //Start the engine :)

            TStripItems.InitToolStripItems();

            // GUI needs to run in another Thread that's inside the main Thread
            // Application will run until this Thread is alive
            Application.Run(); 
        }

        public static void EndApplication(int exitCode = 0)
        {
            if (engine != null)
            {
                engine.Dispose();
            }
            NotifyIcon.Dispose();
            Cxt.Dispose();
            Environment.Exit(exitCode);
        }
    }
}
