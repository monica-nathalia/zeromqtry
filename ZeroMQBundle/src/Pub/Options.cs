﻿namespace Pub
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using CommandLine;
    using CommandLine.Text;

    class Options : CommandLineOptionsBase
    {
        [OptionList("b", "bindEndPoints", Required = true, Separator = ';', HelpText = "List of end points to bind seperated by ';'")]
        public IList<string> bindEndPoints { get; set; }

        [OptionList("m", "AlterMessages", Required = true, Separator = ';', HelpText = "Csv file to parse, in '' format //List of alternative messages to send seperated by ';'. It may contains macros: #nb# = number of the msg")]
        public IList<string> altMessages { get; set; }  

        [Option("x", "MaxNbMessages", Required = false, HelpText = "Max nb message to send. Default -1 (unlimitted)")]
        public long maxMessage { get; set; }  

        [Option("d", "delay", Required = false, HelpText = "Delay between messages (ms). Default = 1000")]
        public int delay { get; set; }            

        [HelpOption(HelpText = "Dispaly this help screen.")]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = "Publisher",               
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            this.HandleParsingErrorsInHelp(help);
            help.AddPreOptionsLine("Usage: Pub.exe -b <bind endpoint list> -m <msgs to send> [-x <max nb msg>] [-d <time delay>]");          
            help.AddOptions(this);

            return help;
        }

        private void HandleParsingErrorsInHelp(HelpText help)
        {
            if (this.LastPostParsingState.Errors.Count > 0)
            {
                var errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces
                if (!string.IsNullOrEmpty(errors))
                {
                    help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
                    help.AddPreOptionsLine(errors);
                }
            }
        }
     
        public Options()
        {
            delay = 1000;
            maxMessage = -1;
        }
    }
}
