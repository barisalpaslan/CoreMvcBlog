using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
