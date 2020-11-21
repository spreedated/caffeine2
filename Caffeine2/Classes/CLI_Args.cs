using CommandLine;
using System;
using WindowsInput.Native;

public static class CLI_Args
{
    public class Options
    {
        [Option('s', "startoff", Required = false, HelpText = "Disable autostart")]
        public bool? Startoff { get; set; }

        [Option('i', "interval", HelpText = "Seconds between keys")]
        public int? Interval { get; set; }

        [Option('k', "key", HelpText = "Key to press, e.g. F15")]
        public string KeyToPressArgument { get; set; }
        public VirtualKeyCode? KeyToPress { get; set; }
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
                       Enum.TryParse<VirtualKeyCode>(o.KeyToPressArgument, out VirtualKeyCode acc);
                       if ((int)acc != 0)
                       {
                           Arguments.KeyToPress = acc;
                       }
                   });
    }
}