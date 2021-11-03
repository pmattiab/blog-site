using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using BlogBusinessLogic.Models;

namespace BlogBusinessLogic.Helper
{
    public class JsonDeserializer
    {
        public T DeserializeJson<T>(string _jsonContent)
        {
            // deserializzo partendo dal contenuto del json
            T deserJson = JsonConvert.DeserializeObject<T>(_jsonContent);

            // ritorno il valore tipizzato deserializzato
            return deserJson;
        }
    }
}