using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortXml.Log {
    public interface ILog {
        void Warn(string message);
        void Error(Exception ex);
        void Info(string message);
        void Log(string message);
        Level LogLevel { get; set; }
    }

    public enum Level { Error = 0, Warning, Info, Log }
}
