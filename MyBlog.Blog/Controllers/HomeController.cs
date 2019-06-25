using MyBlog.Blog.Models;
using MyBlog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                return View();
            }
            else
            {
                using (BlogService service = new BlogService())
                {
                    var result = service.GetBlogs();
                    return View(result);
                }
            }            
        }
        public ActionResult Detail(int id)
        {
            using (BlogService service = new BlogService())
            {
                var result = service.Get(id);
                return View(result);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult _SideBar()
        {
            SidebarModel model = new SidebarModel();

            using (DefinitionService service = new DefinitionService())
            {
                model.CategoryList = service.GetCategories();
            }

            using (BlogService service = new BlogService())
            {
                model.BlogList = service.GetBlogs();
            }

            return PartialView(model);
        }
    }
}