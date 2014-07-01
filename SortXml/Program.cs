using SortXml.Error;
using SortXml.Log;
using SortXml.Model;
using SortXml.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortXml {
    public class Program {
        public static void Main(string[] argList) {
            ILog log = new ConsoleLog();
            var settings = new CmdParser().Parser(argList, log);
            log.LogLevel = settings.LogLevel;
            Run(settings, log);
        }

        private static void Run(Settings settings, ILog log) {
            try {
                string inputXml = string.Empty;
                using (var reader = new FileStream(settings.InputFileName, FileMode.Open, FileAccess.Read))
                using (var streamReader = new StreamReader(reader, Encoding.Default)) {
                    inputXml = streamReader.ReadToEnd();
                }

                var sortedData = new Sorter(log).SortXml(inputXml, settings.Depth);
                using (var writer = new FileStream(settings.OutputFileName, FileMode.OpenOrCreate, FileAccess.Write))
                using (var streamWriter = new StreamWriter(writer, Encoding.Default)) {
                    streamWriter.Write(sortedData);
                }
            }
            catch (InputError ie) {
                log.Error(ie);
            }
            catch (Exception e) {
                log.Error(e);
            }
        }
    }
}
