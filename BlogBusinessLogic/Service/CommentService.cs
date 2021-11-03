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
    public class CommentService
    {
        private EnumFonte fonte;
        private string jsonUrl;
        private string jsonPath;

        public CommentService(EnumFonte _fonte = EnumFonte.WebService)
        {
            this.fonte = _fonte;
            this.jsonUrl = "http://localhost:3000/comments";
            this.jsonPath = "https://jsonplaceholder.typicode.com/comments";
        }

        public List<Comment> GetAll()
        {
            List<Comment> resList = null;

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

            if (resList == null) resList = new List<Comment>();

            return resList;
        }

        public Comment GetSingleComment(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.Id == id);
        }

        private List<Comment> ListFromJson()
        {
            string _jsonPath = this.jsonPath;
            string jsonContent = new JsonReader().ReadJsonFromFile(_jsonPath);
            List<Comment> result = new JsonDeserializer().DeserializeJson<List<Comment>>(jsonContent);

            return result;
        }

        private List<Comment> ListFromWebService()
        {
            string _jsonUrl = this.jsonUrl;
            string jsonContent = new JsonReader().ReadJsonWebService(_jsonUrl);
            List<Comment> result = new JsonDeserializer().DeserializeJson<List<Comment>>(jsonContent);

            return result;
        }
    }
}
