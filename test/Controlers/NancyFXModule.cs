using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Nancy;

namespace nancyfx.Modules
{

    public class NancyFXModule : NancyModule
    {
        public NancyFXModule()
        {
            Get["/Upload"] = param => View["Upload.html"];
            Post["/Upload"] = _ => "<h>Good joke</h>";
            //{

            //    string fileName = FileUpload1.FileName;

            //    FileUpload1.SaveAs(Server.MapPath(@"~\img\") + fileName);
              

            //}
        }
    }
}

