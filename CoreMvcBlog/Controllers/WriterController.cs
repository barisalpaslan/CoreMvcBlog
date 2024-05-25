using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreMvcBlog.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcBlog.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EFWriterRepository());

		[Authorize]
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}
		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var values = wm.GetByIdT(1);
			return View(values);
		}
        [AllowAnonymous]
		[HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
			WriterValidator vv = new WriterValidator();
			ValidationResult results = vv.Validate(p);

			if(results.IsValid) 
			{
				wm.UpdateT(p);
				return RedirectToAction("Index", "Dashboard");
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
			return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
			Writer w = new Writer();
			if(p.WriterImage != null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName);
				var newimage = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimage);
				var stream = new FileStream(location, FileMode.Create);
				p.WriterImage.CopyTo(stream);
				w.WriterImage = newimage;

			}
			w.WriterMail = p.WriterMail;
			w.WriterName = p.WriterName;
			w.WriterPassword = p.WriterPassword;
			w.WriterStatus = true;
			w.WriterAbout = p.WriterAbout;
			wm.AddT(w);
			return RedirectToAction("Index", "Dashboard");
        }
    }
}
