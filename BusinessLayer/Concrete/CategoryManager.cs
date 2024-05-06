using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        // 1- CategoryRepository ctg = new CategoryRepository();

        // 2- GenericRepository<Category> ctg = new GenericRepository<Category>();

        // 3- EFCategoryRepository ctgrepo = new EFCategoryRepository();
        //EFCategoryRepository efCategoryRepository;


        // 3-  public CategoryManager()
        // {
        //     ctgrepo = new EFCategoryRepository();
        // }

        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal _categoryDal)
        {
            categoryDal = _categoryDal;
        }

        public void AddCategory(Category category)
        {
            //if(category.CategoryName != "" && category.CategoryDescription != "" && category.CategoryName.Length >= 5
            //    && category.CategoryStatus == true)
            //{
     //1-   //    ctg.AddCategory(category);
            //}
            //else
            //{
            //    //hata mesajı
            //}

     //3-   // ctgrepo.Insert(category);


            categoryDal.Insert(category);
        }

        public void DeleteCategory(Category category)
        {
            //if(category.ID != 0) 
            //{
     //2-   //    ctg.Delete(category);
            //}


     //3-   //  ctgrepo.Delete(category);

            categoryDal.Delete(category);
        }

        public Category GetById(int id)
        {
     //3-  //  return ctgrepo.GetById(id);

            return categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
     //3-  //  return ctgrepo.GetListAll();

            return categoryDal.GetListAll();
        }

        public void UpdateCategory(Category category)
        {
     //3-  //  ctgrepo.Update(category);

            categoryDal.Update(category);
        }
    }
}
