using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blog_site.Models;

namespace blog_site.BusinessLogic
{
    public class NavbarService
    {
        public List<NavbarModel> GetListFromJson(string _jsonRelativePath)
        {
            string jsonContent = new JsonReader().ReadJson(_jsonRelativePath);

            List<NavbarModel> result = new JsonDeserializer().DeserializeJson<List<NavbarModel>>(jsonContent);

            if (result == null)
            {
                result = new List<NavbarModel>();
            }

            return result;
        }
    }
}