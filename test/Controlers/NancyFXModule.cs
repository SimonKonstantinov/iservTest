using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Nancy;
using Nancy.ModelBinding;

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
                //   var xml = body.IndexOf('<');
                body = body.Substring(body.IndexOf('<'));
                body = body.Remove(body.LastIndexOf('>')+1);

                //string pattern = @"^< ";
                //string target = " ";
                //body = body.Replace("------WebKitFormBoundarySH6HZJ5OdTcNVrdb Content - Disposition: form - data; name = 'file'; filename = '2017-12-12_13-06-36_0300_34744732.xml'", "");
                //Regex regex = new Regex(@"^<", RegexOptions.Multiline );
                //string result = regex.Replace(body,"");


                return Response.AsXml(body);


            };

        }
    }
}
