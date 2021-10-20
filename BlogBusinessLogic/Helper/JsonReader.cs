using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;
using System.Net;

namespace BlogBusinessLogic.Helper
{
    public class JsonReader
    {
        public string ReadJsonFromFile(string _relFilePath)
        {
            string absFilePath = HostingEnvironment.MapPath(_relFilePath);

            string jsonContent = File.ReadAllText(absFilePath);

            return jsonContent;
        }

        public string ReadJsonWebService(string _jsonUrl)
        {

            WebRequest request = WebRequest.Create(_jsonUrl);
            
            WebResponse response = request.GetResponse();
            
            Stream requestStream = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(requestStream);
            
            string jsonContent = reader.ReadToEnd();
            
            return jsonContent;
        }

    }
}