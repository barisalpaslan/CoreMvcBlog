using CoreMvcBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreMvcBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);

            return Json(jsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                ID = 1,
                Name="Ayşe"
            },
            new WriterClass
            {
                ID = 2,
                Name="Ahmet"
            },
            new WriterClass
            {
                ID = 3,
                Name="Buse"
            }
        };
    }
}
