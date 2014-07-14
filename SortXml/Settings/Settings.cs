using CommandLine;
using CommandLine.Text;
using SortXml.Log;

namespace SortXml.Settings {
    internal class Settings {
        [Option('i', "inputfile", 
            Required = true, 
            HelpText="Input XML file to be processed. File to contain syntactically valid XML data only.")]
        public string InputFileName { get; set; }

        [Option('o', "outputfile", 
            Required = true, HelpText = "Output file with sorted XML data.")]
        public string OutputFileName { get; set; }

        [Option('d', "depth", 
            Required = false, HelpText = "Positive integer value to indicate the depth of the XML tree to be processed. Default is to parse the entire tree.")]
        public uint Depth { get; set; }

        [Option('l', "log",
            Required = false, HelpText = "Log level. Error = 0, Warning = 1, Info = 2, Log = 3. Default is to log error and warnings.")]
        public Level LogLevel { get; set; }

        [HelpOption]
        public string GetUsage() {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }

}
