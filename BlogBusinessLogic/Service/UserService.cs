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
        private string jsonUrl;
        private string jsonPath;

        public UserService(EnumFonte _fonte = EnumFonte.WebService)
        {
            this.fonte = _fonte;
            this.jsonUrl = "http://localhost:3000/users";
            this.jsonPath = "https://jsonplaceholder.typicode.com/users";
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
            return this.GetAll().FirstOrDefault(x => x.Id == id);
        }

        private List<User> ListFromJson()
        {
            string _jsonPath = this.jsonPath;
            string jsonContent = new JsonReader().ReadJsonFromFile(_jsonPath);
            List<User> result = new JsonDeserializer().DeserializeJson<List<User>>(jsonContent);

            return result;
        }

        private List<User> ListFromWebService()
        {
            string _jsonUrl = this.jsonUrl;
            string jsonContent = new JsonReader().ReadJsonWebService(_jsonUrl);
            List<User> result = new JsonDeserializer().DeserializeJson<List<User>>(jsonContent);

            return result;
        }
    }
}
