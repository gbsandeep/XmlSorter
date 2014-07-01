using SortXml.Log;
using SortXml.Model;
using SortXml.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortXml {
    class CmdParser : IParser {
        public Settings Parser(string[] input, ILog log) {
            return new Settings() {
                InputFileName = input[0],
                OutputFileName = input[1],
                Depth = input.Length > 2 ? uint.Parse(input[2]) : uint.MaxValue,
                LogLevel = input.Length > 3 ? (Level)uint.Parse(input[3]) : Level.Warning,
            };
        }
    }
}
