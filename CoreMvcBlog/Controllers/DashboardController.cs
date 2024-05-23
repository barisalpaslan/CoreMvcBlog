using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.ToList().Count(); // çözüm1
            //Viewbag.v1 = c.Blogs.Count().ToString() // çözüm2


            ViewBag.v2 = c.Blogs.Where(x => x.WriterId == 1).Count();

            var sevenDaysAgo = DateTime.Now.AddDays(-7);
            ViewBag.v3 = c.Blogs.Count(b => b.CreateDate >= sevenDaysAgo);
            return View();
        }
    }
}
