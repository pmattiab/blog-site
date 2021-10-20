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

        public UserService(EnumFonte _fonte = EnumFonte.WebService)
        {
            this.fonte = _fonte;
        }


        public List<User> GetAll()
        {
            List<User> resList = null;

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

            if (resList == null) resList = new List<User>();

            return resList;
        }

        public User GetSingleUser(int id)
        {
            return new UserService().GetAll().FirstOrDefault(x => x.Id == id);
        }


        private List<User> ListFromJson()
        {
            string jsonPath = "~/Data/users.json";
            string jsonContent = new JsonReader().ReadJsonFromFile(jsonPath);
            List<User> result = new JsonDeserializer().DeserializeJson<List<User>>(jsonContent);

            return result;
        }

        private List<User> ListFromWebService()
        {
            //string jsonUrl = "https://jsonplaceholder.typicode.com/users";
            string jsonUrl = "http://localhost:3000/users";
            string jsonContent = new JsonReader().ReadJsonWebService(jsonUrl);
            List<User> result = new JsonDeserializer().DeserializeJson<List<User>>(jsonContent);

            return result;
        }
    }
}
