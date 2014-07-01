using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortXml.Error {
    internal class InputError : Exception {
        public InputError(string message) : base(message) { }
    }
}
