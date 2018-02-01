
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
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xRoot.HasChildNodes == true)
                {
                    if(  xnode.Name== "forms")
                    {
                        Console.WriteLine("fff: {0}", xnode.InnerText);
                        foreach (XmlNode childForms in xnode.ChildNodes)
                        {
                            if (childForms.Name == "form")
                            {
                                foreach (XmlNode childForm in childForms.ChildNodes)
                                {
                                    if (childForm.Name == "data")
                                    {

                                    }
                                }

                            }

                        }

                    }

                }
                // обходим все дочерние узлы элемента user
              
            }
            foreach (XmlNode childnode in xRoot.ChildNodes)
            {
                // если узел - company
                if (childnode.Name == "date")
                {
                    Console.WriteLine("fff: {0}", childnode.InnerText);
                }
                // если узел age
                if (childnode.Name == "received-date")
                {
                    Console.WriteLine("Возраст: {0}", childnode.InnerText);
                }
                if (childnode.Name == "okato")
                {
                    Console.WriteLine("Возраст: {0}", childnode);
                }
            }
        }
    }
}