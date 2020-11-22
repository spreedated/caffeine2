using CommandLine;
using System;
using WindowsInput.Native;

namespace Caffeine2
{
    public class CLI_Args
    {
        public class Options
        {
            [Option('s', "startoff", Required = false, HelpText = "Disable autostart")]
            public bool Startoff { get; set; }

            [Option('i', "interval", HelpText = "Seconds between keys")]
            public int? IntervalArgument { get; set; }
            public TimeSpan? Interval { get; set; }

            [Option('k', "key", HelpText = "Key to press, e.g. F15")]
            public string KeyToPressArgument { get; set; }
            public VirtualKeyCode? KeyToPress { get; set; }
        }

        public Options Arguments { get; private set; }

        public void ParseArgs(string[] args)
        {
            Arguments = new Options();

            Parser.Default.ParseArguments<Options>(args)
                       .WithParsed<Options>(o =>
                       {
                           Arguments.Startoff = o.Startoff;
                           if (o.IntervalArgument != null)
                           {
                               Arguments.Interval = TimeSpan.FromSeconds((double)o.IntervalArgument);
                           }
                           if (o.KeyToPressArgument != null)
                           {
                               Enum.TryParse<VirtualKeyCode>(o.KeyToPressArgument.ToUpper(), out VirtualKeyCode acc);
                               if ((int)acc != 0)
                               {
                                   Arguments.KeyToPress = acc;
                               }
                           }
                       });
        }
    }
}