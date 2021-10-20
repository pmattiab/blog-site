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

        public PostService(EnumFonte _fonte = EnumFonte.WebService)
        {
            this.fonte = _fonte;
        }


        public List<Post> GetAll()
        {
            List<Post> resList = null;

            switch (this.fonte)
            {
                case EnumFonte.WebService:
                    resList = this.ListFromWebService();
                    break;

                case EnumFonte.Json:
                    resList = this.ListFromJson();
                    break;

                case EnumFonte.Databse:
                    throw new Exception("funzione non implementata");
                    break;

                default:
                    resList = this.ListFromWebService();
                    break;
            }

            if (resList == null) resList = new List<Post>();

            return resList;
        }

        public Post GetSinglePost(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.Id == id);
        }

        private List<Post> ListFromJson()
        {
            string jsonPath = "~/Data/posts.json";
            string jsonContent = new JsonReader().ReadJsonFromFile(jsonPath);
            List<Post> result = new JsonDeserializer().DeserializeJson<List<Post>>(jsonContent);

            return result;
        }

        private List<Post> ListFromWebService()
        {
            //string jsonUrl = "https://jsonplaceholder.typicode.com/posts";
            string jsonUrl = "http://localhost:3000/posts";
            string jsonContent = new JsonReader().ReadJsonWebService(jsonUrl);
            List<Post> result = new JsonDeserializer().DeserializeJson<List<Post>>(jsonContent);

            return result;
        }

    }
}
