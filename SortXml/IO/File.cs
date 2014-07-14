using SortXml.Error;
using SortXml.Log;
using System;
using System.IO;
using System.Text;

namespace SortXml.IO {
    internal static class File {
        internal static string LoadInputFile(string inputFile, ILog log) {
            string inputXml = string.Empty;
            try {
                using (var reader = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (var streamReader = new StreamReader(reader, Encoding.Default)) {
                    inputXml = streamReader.ReadToEnd();
                }
            }
            catch (InputError ie) {
                log.Error(ie);
            }
            catch (Exception e) {
                log.Error(e);
            }
            return inputXml;
        }

        internal static void WriteOutputFile(string outputFile, string sortedData, ILog log) {
            try {
                using (var writer = new FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write))
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
