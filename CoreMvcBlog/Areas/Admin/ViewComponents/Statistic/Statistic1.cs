using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context(); 

        public IViewComponentResult Invoke()
        {
            //Toplam Blog Sayısı
            ViewBag.v1 = bm.GetList().Count();

            ViewBag.v2 = c.Comments.Count();

            ViewBag.v3 = c.Categories.Count();

            ViewBag.v4 = c.Contacts.Count();

            return View();
        }
    }
}
