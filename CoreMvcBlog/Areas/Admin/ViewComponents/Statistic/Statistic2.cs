using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            //Toplam Blog Sayısı
            ViewBag.v1 = c.Blogs.OrderByDescending(x => x.CreateDate).Select(x => x.BlogTitle).Take(1).FirstOrDefault();

           

            return View();
        }
    }
}
