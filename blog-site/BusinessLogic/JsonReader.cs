using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using blog_site.Models;

namespace blog_site.BusinessLogic
{
    public class JsonReader
    {
        public string ReadJson(string relFilePath)
        {
            string absFilePath = System.Web.Hosting.HostingEnvironment.MapPath(relFilePath);

            string jsonContent = File.ReadAllText(absFilePath);

            // ritorno il contenuto del file
            return jsonContent;
        }
    }
}