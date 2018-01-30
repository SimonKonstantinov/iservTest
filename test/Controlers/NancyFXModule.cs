using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;

namespace nancyfx.Modules
{
    class Dinosaur
    {
        public string Name { get; set; }

      
    }
    public class NancyFXModule : NancyModule
    {
     

        private static List<Dinosaur> dinosaurs = new List<Dinosaur>()
    {
    
    };
        

        public NancyFXModule()
        {
            Get["/Upload"] = param => View["Upload.html"];
            Get["/dinosaurs/{id}"] = parameters => dinosaurs[parameters.id - 1];
            Post["/Upload"] = param =>

            {

                var id = this.Request.Body;
                var length = this.Request.Body.Length;
                var data = new byte[length];
                id.Read(data, 0, (int)length);
                var body = System.Text.Encoding.Default.GetString(data);


                return 200;


            };

        }
    }
}

