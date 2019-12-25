using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Lab8_V
{
    class Program
    {
        static string[] NameType = { "Type", "Handy", "Country" };

        static void Main(string[] args)
        {
            //Program Files (x86)\Microsoft SDKs\Windows\v7.0A\bin
            XmlSchemaSetExample xml = new XmlSchemaSetExample();

            if (xml.CheckError)
            {
                ReadXML();
            }

            Console.ReadKey();
        }

        static private void ReadXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Weapon.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                Console.WriteLine("-----------------------");

                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr;

                    for (int i = 0; i < 3; i++)
                    {
                        attr = xnode.Attributes.GetNamedItem(NameType[i]);

                        if (attr != null)
                            Console.WriteLine(NameType[i] + ": " + attr.Value);
                    }
                }

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Visual")
                    {
                        foreach (XmlNode childnode1 in childnode.ChildNodes)
                        {
                            Console.WriteLine($"{childnode1.Name}: {childnode1.InnerText}");
                        }
                    }

                    if (childnode.Name == "price")
                    {
                        Console.WriteLine($"Price: {childnode.InnerText}$");
                    }
                }
            }
        }
    }
}