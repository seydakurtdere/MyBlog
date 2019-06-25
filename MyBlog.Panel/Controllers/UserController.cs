using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Panel.Controllers
{
    public class UserController : Controller
    {
        //List: FullName, CityName, TownName, EmailAddress,UserTypeName, Detay
        //Save
        //IsEmailVerified=true
        //UserTypeID=2
        public ActionResult Index()
        {
            return View();
        }
    }
}