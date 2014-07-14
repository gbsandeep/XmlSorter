using System;

namespace SortXml.Log {
    public class ConsoleLog : ILog {
        public ConsoleLog(Level level = Level.Warning) {
            this.LogLevel = level;
        }
        public void Warn(string message) {
            if (LogLevel >= Level.Warning) {
                WriteMessage(message, ConsoleColor.Yellow);
            }
        }

        public void Error(Exception ex) {
            WriteMessage(ex.Message, ConsoleColor.Red);
        }

        public void Info(string message) {
            if (LogLevel >= Level.Info) {
                WriteMessage(message, ConsoleColor.White);
            }
        }

        public void Log(string message) {
            if (LogLevel >= Level.Log) {
                WriteMessage(message, ConsoleColor.DarkGray);
            }
        }

        private static void WriteMessage(string message, ConsoleColor textColor) {
            var oldValue = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldValue;
        }

        public Level LogLevel {
            get;
            set;
        }
    }

}
