using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.ViewComponents.Writers
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        public IViewComponentResult Invoke()
        {
            var values = wm.GetWriterById(1);
            return View(values);
        }
    }
}
