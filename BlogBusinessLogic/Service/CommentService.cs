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

        public CommentService(EnumFonte _fonte = EnumFonte.WebService)
        {
            this.fonte = _fonte;
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
            return new CommentService().GetAll().FirstOrDefault(x => x.Id == id);
        }

        private List<Comment> ListFromJson()
        {
            string jsonPath = "~/Data/comments.json";
            string jsonContent = new JsonReader().ReadJsonFromFile(jsonPath);
            List<Comment> result = new JsonDeserializer().DeserializeJson<List<Comment>>(jsonContent);

            return result;
        }

        private List<Comment> ListFromWebService()
        {
            //string jsonUrl = "https://jsonplaceholder.typicode.com/comments";
            string jsonUrl = "http://localhost:3000/comments";
            string jsonContent = new JsonReader().ReadJsonWebService(jsonUrl);
            List<Comment> result = new JsonDeserializer().DeserializeJson<List<Comment>>(jsonContent);

            return result;
        }
    }
}
