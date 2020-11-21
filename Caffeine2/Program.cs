using System;
using System.Data;
using System.Linq;
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
            CLI_Args.ParseArgs(args); //Process arguments
            engine = new CaffeineEngine(CLI_Args.Arguments.Startoff??true); //Instance without autorun
#if DEBUG
            engine.KeyPressInterval = new TimeSpan(0,0,12);
#endif
            //Process args
            args.ToList().ForEach((x)=> { Debug.Print(x); });
            
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
