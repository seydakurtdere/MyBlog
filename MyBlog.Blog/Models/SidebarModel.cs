using MyBlog.DTO;
using System.Collections.Generic;

namespace MyBlog.Blog.Models
{
    public class SidebarModel
    {
        public List<CategoryDTO> CategoryList { get; set; }
        public List<BlogDTO> BlogList { get; set; }
    }
}