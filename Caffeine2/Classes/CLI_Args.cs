using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Caffeine2;
using WindowsInput.Native;

public static class CLI_Args
{
    public class Options
    {
        [Option('s', "startoff", Required = false, HelpText = "Disable autostart")]
        public bool Startoff { get; set; }

        [Option('i',"interval", HelpText = "Seconds between keys")]
        public int? Interval { get; set; }

        [Option('k', "key", HelpText = "Seconds between keys")]
        public VirtualKeyCode KeyToPress { get; set; }
    }

    public static Options Arguments { get; private set; }

    public static void ParseArgs(string[] args)
    {
        Arguments = new Options();

        Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       Arguments.Startoff = o.Startoff;
                       Arguments.Interval = o.Interval;
                       //TODO: Arg Keycode
                   });
    }
}