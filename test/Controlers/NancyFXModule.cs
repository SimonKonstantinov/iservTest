using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Nancy;

namespace nancyfx.Modules

{
    public class NancyFXModule : NancyModule
    {


        public NancyFXModule()
        {
            Get["/Upload"] = param => View["Upload.html"];


            Post["/Upload"] = param =>

            {

                var id = this.Request.Body;
                var length = this.Request.Body.Length;
                var data = new byte[length];
                id.Read(data, 0, (int)length);
                string body = System.Text.Encoding.UTF8.GetString(data);

                ClipXML(ref body);
                SearchXML(ref body);


                return View["View.html"];
            };
        }

        string ClipXML(ref string XML)
        {
            XML = XML.Substring(XML.IndexOf('<'));
            XML = XML.Remove(XML.LastIndexOf('>') + 1);
            return XML;
        }

        public string SearchXML(ref string body)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(body);
     
            XmlElement xRoot = xDoc.DocumentElement;
            List<string> XmLList = new List<string>();
            {
                XmLList.Add((xRoot.SelectSingleNode("//user/@id").Value));

                XmLList.Add(Convert.ToString(xRoot.SelectSingleNode("//service/@id").Value));

                XmLList.Add(Convert.ToString(xRoot.SelectSingleNode("//service").InnerText));
                XmLList.Add((xRoot.SelectSingleNode(("//date")).InnerText));
                XmLList.Add((xRoot.SelectSingleNode("//data/received-date").InnerText));
                XmLList.Add(xRoot.SelectSingleNode("//okato").InnerText);
                return "t";

            };

        }
    }
}






