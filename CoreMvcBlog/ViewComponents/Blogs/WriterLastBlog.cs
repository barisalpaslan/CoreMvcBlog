using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.ViewComponents.Blogs
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager bm = new BlogManager(new EFBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListWithWriter(1);
			return View(values);
		}
	}
}
