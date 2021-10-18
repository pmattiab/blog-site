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

        public CommentService(EnumFonte _fonte = EnumFonte.Json)
        {
            this.fonte = _fonte;
        }


        public List<Comment> GetAll()
        {
            List<Comment> resList = null;

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

            if (resList == null) resList = new List<Comment>();

            return resList;
        }


        private List<Comment> ListFromJson()
        {
            string jsonPath = "~/Data/comments.json";
            string jsonContent = new JsonReader().ReadJson(jsonPath);
            List<Comment> result = new JsonDeserializer().DeserializeJson<List<Comment>>(jsonContent);

            return result;
        }
    }
}
