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
    public class UserService
    {
        private EnumFonte fonte;

        public UserService(EnumFonte _fonte = EnumFonte.Json)
        {
            this.fonte = _fonte;
        }


        public List<User> GetAll()
        {
            List<User> resList = null;

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

            if (resList == null) resList = new List<User>();

            return resList;
        }


        private List<User> ListFromJson()
        {
            string jsonPath = "~/Data/users.json";
            string jsonContent = new JsonReader().ReadJson(jsonPath);
            List<User> result = new JsonDeserializer().DeserializeJson<List<User>>(jsonContent);

            return result;
        }
    }
}
