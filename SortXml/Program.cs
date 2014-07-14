using SortXml.Log;
using SortXml.Sort;

namespace SortXml {
    public class Program {
        public static void Main(string[] argList) {
            ILog log = new ConsoleLog();
            var settings = new Settings.Settings();
            if (CommandLine.Parser.Default.ParseArguments(argList, settings)) {
                log.LogLevel = settings.LogLevel;
                Run(settings, log);
            }
        }

        private static void Run(Settings.Settings settings, ILog log) {
            string inputXml = IO.File.LoadInputFile(settings.InputFileName, log);
            var sortedData = new Sorter(log).SortXml(inputXml, settings.Depth);
            IO.File.WriteOutputFile(settings.OutputFileName, sortedData, log);
        }
    }
}
