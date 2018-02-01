using System;
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
              string body = System.Text.Encoding.Default.GetString(data);


                body = body.Substring(body.IndexOf('<'));
                body = body.Remove(body.LastIndexOf('>') + 1);

                System.IO.File.WriteAllText(@"C:\Users\skons\Source\Repos\iservTest\test\Files\data.xml", body);
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"C:\Users\skons\Source\Repos\iservTest\test\Files\data.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                // выбор всех дочерних узлов
                XmlNodeList childnodes = xRoot.SelectNodes("//rates");
                foreach (XmlNode n in childnodes)
                {

                }

                return Response.AsXml(childnodes);


            };

        }
    }
}
