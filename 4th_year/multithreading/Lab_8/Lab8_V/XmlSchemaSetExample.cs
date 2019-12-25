using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Lab8_V
{
    public class XmlSchemaSetExample
    {
        static bool checkError = true;
        public bool CheckError { get => checkError; }

        public XmlSchemaSetExample()
        {
            XmlReaderSettings booksSettings = new XmlReaderSettings();
            booksSettings.Schemas.Add("http://www.contoso.com/books", "Weapon.xsd");
            booksSettings.ValidationType = ValidationType.Schema;
            booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

            XmlReader books = XmlReader.Create("Weapon.xml", booksSettings);

            while (books.Read()) { }

            if (CheckError)
            {
                Console.WriteLine("XML - true");
            }
            else
            {
                Console.WriteLine("XML - false");
            }
        }

        static void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);

                checkError = false;
            }
        }
    }
}