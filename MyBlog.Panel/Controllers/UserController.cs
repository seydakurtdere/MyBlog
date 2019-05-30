using MyBlog.DTO;
using MyBlog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Panel.Controllers
{
    public class UserController : Controller
    {
        //list :FullName, cityName, TownName, EmailAdress UserTypeName Detay
        // GET: User
        public ActionResult Index()
        {
            if (Session["loginuser"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            using (UserService service = new UserService())
            {
                var users = service.List();
                return View(users);
            }

        }

        public ActionResult Get(int id)
        {
            using (UserService service = new UserService())
            {
                var result = service.Get(id);

                return View(result);
            }

        }

        public ActionResult Save()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(UserDTO obj)
        {
            using (UserService service = new UserService())
            {

                    obj.UserTypeID = 2;
                    var result = service.Register(obj);
                    if (result)
                    {
                        //Category/Get/5
                        return RedirectToAction("Get", new { id = result });
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Bir hata oluştu.";
                        return View();
                    } 
                
            }
        }

    }
}