using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreMvcBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetListT().ToPagedList(page, 2);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            c.CategoryStatus = true;
            cm.AddT(c);
            return RedirectToAction("Index","Category");
        }
        public IActionResult CategoryPassive(int id)
        {
            var value = cm.GetByIdT(id);
            value.CategoryStatus = false;
            cm.UpdateT(value);
            return RedirectToAction("Index", "Category");
        }
        public IActionResult CategoryActive(int id)
        {
            var value = cm.GetByIdT(id);
            value.CategoryStatus = true;
            cm.UpdateT(value);
            return RedirectToAction("Index", "Category");
        }
    }
}
