using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BlogBusinessLogic.Helper
{
    public class JsonSerializer
    {
        public string SerializeJson(object objToSer)
        {
            string jsonSer = JsonConvert.SerializeObject(objToSer);

            return jsonSer;
        }
    }
}
