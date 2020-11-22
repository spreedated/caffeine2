using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Caffeine2
{
    public class Program
    {
        public static CaffeineEngine engine;
        public static NotifyIcon NotifyIcon;
        public static ContextMenuStrip Cxt;
        public static CLI_Args CommandLineOptions;

        public static void Main(string[] args)
        {
            CommandLineOptions = new CLI_Args();
            CommandLineOptions.ParseArgs(args); //Process arguments
            engine = new CaffeineEngine(!CommandLineOptions.Arguments.Startoff);
#if DEBUG
            engine.KeyPressInterval = new TimeSpan(0, 0, 12);
#endif
            //Process args
            args.ToList().ForEach((x) => { Debug.Print(x); });

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
