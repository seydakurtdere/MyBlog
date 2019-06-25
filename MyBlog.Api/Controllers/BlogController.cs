using MyBlog.DTO;
using MyBlog.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyBlog.Api.Controllers
{
    public class BlogController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Save(BlogDTO obj)
        {
            using (BlogService blogService = new BlogService())
            {
                obj.ImagePath = "";
                var result = blogService.Save(obj);

                if (result > 0)
                {
                    return Content(HttpStatusCode.OK, true);
                }
                else
                {
                    return InternalServerError();
                }
            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Upload(int id)
        {
            using (BlogService service = new BlogService())
            {
                var blog = service.Get(id);

                var allowedExtensions = new[] { ".jpeg", ".png", ".jpg" };

                HttpFileCollection hfc = HttpContext.Current.Request.Files;

                if (hfc.Count > 0)
                {
                    try
                    {
                        HttpPostedFile file = hfc[0];

                        if (allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                        {
                            string rootPath = Path.Combine(HostingEnvironment.MapPath("~/"), "files", "blogs");
                            // 3_blog_004F6897-5BC9-44EA-898C-E69A6368E71B.jpg
                            string fileName = id + "_blog_" + Guid.NewGuid() + Path.GetExtension(file.FileName);

                            if (!string.IsNullOrEmpty(blog.ImagePath))
                            {
                                File.Delete(Path.Combine(rootPath, blog.ImagePath));
                            }

                            file.SaveAs(Path.Combine(rootPath, fileName));

                            blog.ImagePath = fileName;
                            var result = service.Update(blog);

                            if (result)
                            {
                                return Ok(true);
                            }
                            else
                            {
                                return InternalServerError();
                            }
                        }
                        else
                        {
                            return Unauthorized();
                        }
                    }
                    catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
