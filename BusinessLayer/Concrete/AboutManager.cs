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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void AddT(About t)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(About t)
        {
            throw new NotImplementedException();
        }

        public About GetByIdT(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetListT()
        {
            return _aboutdal.GetListAll();
        }

        public void UpdateT(About t)
        {
            throw new NotImplementedException();
        }
    }
}
