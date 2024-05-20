using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			this._blogDal = blogDal;
		}

		

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}

		public List<Blog> GetLastThreeBlog()
		{
			return _blogDal.GetListAll().Take(3).ToList();
		}


		public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetBlogListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x => x.ID == id);
		}

      

		public List<Blog> GetBlogListWithWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterId == id);
		}

        public void AddT(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void UpdateT(Blog t)
        {
            _blogDal.Update(t);
        }

        public void DeleteT(Blog t)
        {
            _blogDal.Delete(t);
        }

        public List<Blog> GetListT()
        {
            throw new NotImplementedException();
        }

        public Blog GetByIdT(int id)
        {
            return _blogDal.GetById(id);
        }
    }
}
