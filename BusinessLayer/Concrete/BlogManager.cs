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

		public void AddBlog(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void DeleteBlog(Blog blog)
		{
			throw new NotImplementedException();
		}

		public Blog GetById(int id)
		{
			throw new NotImplementedException();
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
        public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x => x.ID == id);
		}

        public void UpdateBlog(Blog blog)
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetBlogListWithWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterId == id);
		}
	}
}
