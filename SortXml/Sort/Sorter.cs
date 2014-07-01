using SortXml.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SortXml.Sort {
    public class Sorter {
        public ILog log { get; set; }
        public Sorter(ILog log) {
            this.log = log;
        }
        public string SortXml(string inputXml, uint maxDepth = uint.MaxValue) {
            var output = new StringBuilder();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(inputXml);
            XDocument xDoc = XDocument.Parse(inputXml);
            SortXmlRecursive(xDoc.Root, maxDepth);
            return xDoc.ToString();
        }

        /// <summary>
        /// Method to sort all the elements in an XML tree
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        XElement SortXmlRecursive(XElement parent, uint maxDepth) {
            log.Log("Processing node: " + parent.Name);
            if (maxDepth <= 0) {
                log.Warn("Maximum depth reached: " + parent.Name);
            }
            else {
                var children = parent.Elements().ToList();
                SortChildren(parent, children, maxDepth);
                SortAttributes(parent);
                SortElements(parent);
            }
            return parent;
        }

        /// <summary>
        /// Recursively sort all the children
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="children"></param>
        private void SortChildren(XElement parent, List<XElement> children, uint maxDepth) {
            parent.Elements().Remove();
            foreach (var child in children) {
                parent.Add(SortXmlRecursive(child, maxDepth - 1));
            }
        }

        /// <summary>
        /// Sort all the child elements of an element
        /// </summary>
        /// <param name="parent"></param>
        private void SortElements(XElement parent) {
            log.Log("Sorting elements of: " + parent.Name);
            var children = parent.Elements().ToList();
            if (children.Count > 1) {
                parent.Elements().Remove();
                children.Sort((a, b) => {
                    return getSortKey(a).CompareTo(getSortKey(b));
                });
                parent.Add(children);
            }
        }

        /// <summary>
        /// Key consisting of element name, attribute key-value pair separated by delimitera 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private string getSortKey(XElement a, string delimiter = "_") {
            return a.Name.LocalName.ToString() + delimiter + 
                string.Join(delimiter, a.Attributes().Select(n => n.Name.ToString() + delimiter + n.Value.ToString()));
        }

        /// <summary>
        /// Sort all the attributes within an element
        /// </summary>
        /// <param name="parent"></param>
        private static void SortAttributes(XElement parent) {
            var attributes = parent.Attributes().ToList();
            if (attributes.Count > 1) {
                parent.Attributes().Remove();
                attributes.Sort((a, b) => a.Name.LocalName.CompareTo(b.Name.LocalName));
                parent.Add(attributes);
            }
        }
    }
}
