﻿using BusinessLayer.Abstract;
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
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddT(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void DeleteT(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category GetByIdT(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetListT()
        {
            return _categoryDal.GetListAll();
        }

        public void UpdateT(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
