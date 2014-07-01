using SortXml.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortXml.Model {
    internal class Settings {
        public string InputFileName { get; set; }
        public bool DryRun { get; set; }
        public string OutputFileName { get; set; }
        public uint Depth { get; set; }
        public Level LogLevel { get; set; }
    }

}
