using SortXml.Log;
using SortXml.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortXml.Parser {
    interface IParser {
        Settings Parser(string[] input, ILog log);
    }
}
