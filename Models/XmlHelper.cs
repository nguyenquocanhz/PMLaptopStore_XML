using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace PMLaptopStore_XML.Models
{
    public class XmlHelpers
    {
        // Private constructor for Singleton
        private static XmlHelpers instance;
        public static XmlHelpers Instance
        {
            get
            {
                if (instance == null)
                    instance = new XmlHelpers();
                return instance;
            }
            private set { instance = value; }
        }
        public XmlHelpers() { }

        // Load dữ liệu file data.xml ví dụ nhanvien.xml
        private XDocument LoadDocument(string filePath)
        {
            try
            {
                return XDocument.Load(filePath);
            }
            catch (Exception ex)
            {
                throw new XmlException($"Failed to load XML file at {filePath}: {ex.Message}");
            }
        }
        public void CheckFileExist(string fileName)
        {
            if (!File.Exists(fileName))
            {
                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("nhanviens", // Root element
                        new XElement("nhanvien",
                            new XAttribute("ma", "NV001"),
                            new XElement("thongtin",
                                new XElement("hovaten", "Nguyen Van A"),
                                new XElement("ngaysinh", "1990-05-20"),
                                new XElement("sodienthoai", "0123456789"),
                                new XElement("chucvu", "Quan ly"),
                                new XElement("phongban", "Kinh doanh"),
                                new XElement("ngaytuyendung", "2015-08-01"),
                                new XElement("info", "nguyenquocanh|anhanh123|admin")
                            )
                        )
                    )
                );

                doc.Save(fileName);
            }
        }
        // Lưu dữ liệu data xml
        private void SaveDocument(XDocument document, string filePath)
        {
            try
            {
                document.Save(filePath);
            }
            catch (Exception ex)
            {
                throw new XmlException($"Failed to save XML file at {filePath}: {ex.Message}");
            }
        }

        // Read the value of an XML node
        public string GetNodeValue(string filePath, string nodeName)
        {
            var doc = LoadDocument(filePath);
            var element = doc.Descendants(nodeName).FirstOrDefault();
            return element?.Value;
        }

        // Add or update an XML node
        public void AddOrUpdateNode(string filePath, string nodeName, string value)
        {
            var doc = LoadDocument(filePath);
            var element = doc.Descendants(nodeName).FirstOrDefault();

            if (element != null)
            {
                element.Value = value;
            }
            else
            {
                var newElement = new XElement(nodeName, value);
                doc.Root?.Add(newElement);
            }

            SaveDocument(doc, filePath);
        }

        // Delete an XML node
        public void DeleteNode(string filePath, string nodeName)
        {
            var doc = LoadDocument(filePath);
            var element = doc.Descendants(nodeName).FirstOrDefault();

            if (element != null)
            {
                element.Remove();
                SaveDocument(doc, filePath);
            }
        }

        // Read all values of a specific XML node
        public List<string> GetAllNodeValues(string filePath, string nodeName)
        {
            var doc = LoadDocument(filePath);
            return doc.Descendants(nodeName)
                     .Select(node => node.Value)
                     .ToList();
        }

        // Find an XML node by attribute
        public XElement FindNodeByAttribute(string filePath, string nodeName, string attributeName, string attributeValue)
        {
            var doc = LoadDocument(filePath);
            return doc.Descendants(nodeName)
                      .FirstOrDefault(node => node.Attribute(attributeName)?.Value == attributeValue);
        }
    }
}