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
    public class AdminManager : IAdminService
    {
        public IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddT(Admin t)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(Admin t)
        {
            throw new NotImplementedException();
        }

        public Admin GetByIdT(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetListT()
        {
            throw new NotImplementedException();
        }

        public void UpdateT(Admin t)
        {
            throw new NotImplementedException();
        }
    }
}
