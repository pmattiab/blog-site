using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using blog_site.Models;


namespace blog_site.BusinessLogic
{
    public class PostService
    {
        public List<PostModel> ListFromJson()
        {
            string jsonPath = "~/Data/posts.json";

            string jsonContent = new JsonReader().ReadJson(jsonPath);

            List<PostModel> result = new JsonDeserializer().DeserializeJson<List<PostModel>>(jsonContent);

            if (result == null)
            {
                result = new List<PostModel>();
            }

            return result;
        }

    }
}