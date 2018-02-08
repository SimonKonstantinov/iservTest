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
                if (length<200)
                {
                    return View["Error.html"];
                }
                ClipXML(ref body);

                List<string> XMLTForm = new List<string>();
                List<string> XMLTRates = new List<string>();
                SearchTagForm(ref body, ref XMLTForm);
                SearchTagRates(ref body, ref XMLTForm);
           //     View["ViewRates.html", XMLTRates];
                return View["ViewData.html", XMLTForm]; 
            };
        }

        string ClipXML(ref string XML)
        {
            XML = XML.Substring(XML.IndexOf('<'));
            XML = XML.Remove(XML.LastIndexOf('>') + 1);
            return XML;
        }

   

        public void SearchTagRates(ref string body, ref List<string> XMLTRates)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(body);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("//rate");
            foreach (XmlNode n in childnodes)
            {
                XMLTRates.Add(n.InnerText);
            }
        }

        public void SearchTagForm(ref string body, ref List<string> XmLList)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(body);
     
            XmlElement xRoot = xDoc.DocumentElement;
            
                XmLList.Add((xRoot.SelectSingleNode("//user/@id").Value));

                XmLList.Add(Convert.ToString(xRoot.SelectSingleNode("//service/@id").Value));

                XmLList.Add(Convert.ToString(xRoot.SelectSingleNode("//service").InnerText));
                XmLList.Add(xRoot.SelectSingleNode("//date").InnerText);
                XmLList.Add(xRoot.SelectSingleNode("//data/received-date").InnerText);
            XmLList.Add(xRoot.SelectSingleNode("//okato").InnerText);
        }
    }
}






