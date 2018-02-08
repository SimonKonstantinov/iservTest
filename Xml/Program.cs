
using System;
using System.Collections.Generic;
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

            //Console.WriteLine(xRoot.SelectSingleNode("//service").InnerText);
            //Console.WriteLine(xRoot.SelectSingleNode("//date").InnerText);
            //Console.WriteLine(xRoot.SelectSingleNode("//data/received-date").InnerText);
            //Console.WriteLine(xRoot.SelectSingleNode("//okato").InnerText);

            //Console.WriteLine(xRoot.SelectSingleNode("//rates/rate").InnerText);

            List<string> XmLList = new List<string>();
            {
                // XmLList.Add((xRoot.SelectSingleNode("//user/@id").Value));

                // XmLList.Add(Convert.ToString(xRoot.SelectSingleNode("//service/@id").Value));

                // XmLList.Add(Convert.ToString(xRoot.SelectSingleNode("//service").InnerText));        
                // XmLList.Add((xRoot.SelectSingleNode(("//date")).InnerText));
                // XmLList.Add((xRoot.SelectSingleNode("//data/received-date").InnerText));
                //XmLList.Add(xRoot.SelectSingleNode("//okato").InnerText);
                XmlNodeList childnodes = xRoot.SelectNodes("//rate");
                foreach (XmlNode n in childnodes)
                {
                    //if ()
                    //{
                        XmLList.Add(n.InnerText );
                    //}
                }
                    
            };
            foreach (string i in XmLList)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}