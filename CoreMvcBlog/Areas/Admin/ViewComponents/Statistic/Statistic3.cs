using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.Areas.Admin.ViewComponents.Statistic
{
    [Area("Admin")]
    public class Statistic3 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x => x.ID == 1).Select(x =>x.Name).FirstOrDefault();

            ViewBag.v2 = c.Admins.Where(x => x.ID == 1).Select(x =>x.ImageURL).FirstOrDefault();

            ViewBag.v3 = c.Admins.Where(x => x.ID == 1).Select(x =>x.ShortDescription).FirstOrDefault();

            return View();
        }
    }
}
