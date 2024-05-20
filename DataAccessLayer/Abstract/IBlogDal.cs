using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory(); //sadece Blog'a özel bir method olacağı için generic değil, ayrı olarak tanımlandı.
        List<Blog> GetListWithCategoryByWriter(int id);
        //List<Blog> ListAllBlog();
        //void AddBlog(Blog category);
        //void UpdateBlog(Blog category);
        //void DeleteBlog(Blog category);
        //Blog GetBlogById(int id);
    }
}
