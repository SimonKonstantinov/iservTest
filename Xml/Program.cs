
using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Xml
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\skons\Source\Repos\iservTest\test\Files\data.xml");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
    

            
            //      XmlNode dareceived_datete = xRoot.SelectSingleNode("//data/received-date");
            Console.WriteLine(xRoot.SelectSingleNode("//user/@id").Value);
            Console.WriteLine(xRoot.SelectSingleNode("//service/@id").Value);
            Console.WriteLine(xRoot.SelectSingleNode("//service").InnerText);
            Console.WriteLine(xRoot.SelectSingleNode("//date").InnerText);
            Console.WriteLine(xRoot.SelectSingleNode("//data/received-date").InnerText);
            Console.WriteLine(xRoot.SelectSingleNode("//okato").InnerText);

            Console.WriteLine(xRoot.SelectSingleNode("//rates/rate").InnerText);


        }
    }
}