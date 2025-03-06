using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMLaptopStore_XML.Models
{
    public class Helpers
    {
        // Helpers constructor
        public Helpers()
        {
        }
        // instace of Helpers
        private static Helpers instance;
        public static Helpers Instance
        {
            get
            {
                if (instance == null)
                    instance = new Helpers();
                return instance;
            }
            private set { instance = value; }
        }
        // check string input txtUsername, txtPassword is empty or not
        public static bool IsEmpty(string txtUsername, string txtPassword)
        {
            if (string.IsNullOrEmpty(txtUsername) || string.IsNullOrEmpty(txtPassword))
            {
                return true;
            }
            return false;
        }
        // format currency vnd
        public static string FormatCurrency(string price)
        {
            return string.Format("{0:#,##0} VNĐ", double.Parse(price));
        }
        public static string FormatCurrency(decimal price)
        {
            return string.Format("{0:#,##0} VNĐ", price);
        }

        // format date
        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        // format date time
        public static string FormatDateTime(DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm:ss");
        }
        // READ XML FILE
        public static string ReadXML(string path, string node)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(path);
            System.Xml.XmlNodeList nodeList = doc.GetElementsByTagName(node);
            return nodeList[0].InnerText;
        }
        // WRITE XML FILE
        public static void WriteXML(string path, string node, string value)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(path);
            System.Xml.XmlNodeList nodeList = doc.GetElementsByTagName(node);
            nodeList[0].InnerText = value;
            doc.Save(path);
        }

        // check string input is number or not
        public static bool IsNumber(string txt)
        {
            foreach (char c in txt)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        // check string input is email or not
        public static bool IsEmail(string txt)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(txt);
                return addr.Address == txt;
            }
            catch
            {
                return false;
            }
        }

        // check string input is phone number or not
        public static bool IsPhoneNumber(string txt)
        {
            if (txt.Length < 10 || txt.Length > 11)
                return false;
            foreach (char c in txt)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        // SHOW MESSAGE BOX
        public static void ShowMessageBox(string message, string caption, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon)
        {
            System.Windows.Forms.MessageBox.Show(message, caption, buttons, icon);
        }
        // load image
        public static System.Drawing.Image LoadImage(string path)
        {
            return System.Drawing.Image.FromFile(path);
        }
        // save image
        public static void SaveImage(System.Drawing.Image image, string path)
        {
            image.Save(path);
        }
        // checkFileExists
        public static bool CheckFileExists(string path)
        {
            return System.IO.File.Exists(path);
        }
        // checkTypeFile
        public static bool CheckTypeFile(string path, string type)
        {
            return System.IO.Path.GetExtension(path) == type;
        }
        // checkFolderExists
        public static bool CheckFolderExists(string path)
        {
            return System.IO.Directory.Exists(path);
        }
        // createFolder
        public static void CreateFolder(string path)
        {
            System.IO.Directory.CreateDirectory(path);
        }
        // deleteFolder
        public static void DeleteFolder(string path)
        {
            System.IO.Directory.Delete(path);
        }
        // deleteFile
        public static void DeleteFile(string path)
        {
            System.IO.File.Delete(path);
        }
        // copyFile
        public static void CopyFile(string source, string destination)
        {
            System.IO.File.Copy(source, destination);
        }
        // moveFile
        public static void MoveFile(string source, string destination)
        {
            System.IO.File.Move(source, destination);
        }
        // getFileName
        public static string GetFileName(string path)
        {
            return System.IO.Path.GetFileName(path);
        }
        // getFileNameWithoutExtension
        public static string GetFileNameWithoutExtension(string path)
        {
            return System.IO.Path.GetFileNameWithoutExtension(path);
        }
        // getExtension
        public static string GetExtension(string path)
        {
            return System.IO.Path.GetExtension(path);
        }
        // make xml struct for users

    }
}
