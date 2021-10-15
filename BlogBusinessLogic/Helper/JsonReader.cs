using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;

namespace BlogBusinessLogic.Helper
{
    public class JsonReader
    {
        public string ReadJson(string relFilePath)
        {
            string absFilePath = HostingEnvironment.MapPath(relFilePath);

            string jsonContent = File.ReadAllText(absFilePath);

            // ritorno il contenuto del file
            return jsonContent;
        }
    }
}