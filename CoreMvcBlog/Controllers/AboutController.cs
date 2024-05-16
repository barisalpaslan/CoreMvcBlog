using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm = new AboutManager(new EFAboutRepository());
		public IActionResult Index()
		{
            var values = abm.GetListT();
            return View(values);
		}
		public PartialViewResult SocialMedia()
		{
			return PartialView();
		}
	}
}
