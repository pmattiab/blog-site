using BlogBusinessLogic.Helper;
using BlogBusinessLogic.Models;
using BlogBusinessLogic.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusinessLogic.Service
{
    public class PostService
    {

        private EnumFonte fonte;

        public PostService(EnumFonte _fonte = EnumFonte.Json)
        {
            this.fonte = _fonte;
        }


        public List<Post> GetAll()
        {
            List<Post> resList = null;
            switch (this.fonte)
            {
                case EnumFonte.Json:
                    resList = this.ListFromJson();
                    break;

                case EnumFonte.Databse:
                case EnumFonte.WebService:
                    throw new Exception("funzione non implemtata");
                    break;

                default:
                    resList = ListFromJson();
                    break;
            }

            if (resList == null) resList = new List<Post>();

            return resList;
        }


        private List<Post> ListFromJson()
        {
            string jsonPath = "~/Data/posts.json";
            string jsonContent = new JsonReader().ReadJson(jsonPath);
            List<Post> result = new JsonDeserializer().DeserializeJson<List<Post>>(jsonContent);

            return result;
        }

    }
}
