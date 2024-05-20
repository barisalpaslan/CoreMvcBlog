using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Collections.Generic;

namespace CoreMvcBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var values = bm.GetBlogListWithCategoryByWriter(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EFCategoryRepository());

            List<SelectListItem> category = (from x in cm.GetListT()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.ID.ToString()
                                             }).ToList();

            ViewBag.cat = category;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator validationRules = new BlogValidator();
            ValidationResult results = validationRules.Validate(p);

            //hata çözümü
            CategoryManager cm = new CategoryManager(new EFCategoryRepository());

            List<SelectListItem> category = (from x in cm.GetListT()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.ID.ToString()
                                             }).ToList();

            ViewBag.cat = category;


            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = 1;
                bm.AddT(p);
                return RedirectToAction("BlogListByWriter","Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.GetByIdT(id);
            bm.DeleteT(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EFCategoryRepository());

            List<SelectListItem> category = (from x in cm.GetListT()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.ID.ToString()
                                             }).ToList();

            ViewBag.cat = category;

            var blogvalue = bm.GetByIdT(id);
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            b.WriterId = 1;
            b.BlogStatus = true;
            b.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.UpdateT(b);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
