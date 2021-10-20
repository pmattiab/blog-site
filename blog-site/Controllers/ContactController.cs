using blog_site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace blog_site.Controllers
{
    public class ContactController : Controller
    {

        public ActionResult SuccessMessage()
        {
            return View();
        }
    }
}