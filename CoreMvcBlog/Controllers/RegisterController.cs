using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(writer);

            if(results.IsValid)
            {
				writer.WriterStatus = true;
				writer.WriterAbout = "Deneme test";
				wm.AddWriter(writer);
				return RedirectToAction("Index");
			}
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
		}
	}
}
