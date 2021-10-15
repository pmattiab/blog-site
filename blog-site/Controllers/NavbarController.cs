using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blog_site.Models;
using blog_site.BusinessLogic;

namespace blog_site.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public List<NavbarModel> GetNavLarList()
        {
            string jsonPath = "~/Data/navbar-list.json";

            List<NavbarModel> navbarList = new NavbarService().GetListFromJson(jsonPath);

            return navbarList;
        }
    }
}