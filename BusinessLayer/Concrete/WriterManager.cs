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
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal) 
		{
			_writerDal = writerDal;
		}

        public void AddT(Writer t)
        {
            _writerDal.Insert(t);
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetListAll(x => x.WriterID == id);
        }


        public void DeleteT(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer GetByIdT(int id)
        {
            return _writerDal.GetById(id);
        }

        public List<Writer> GetListT()
        {
            throw new NotImplementedException();
        }


        public void UpdateT(Writer t)
        {
            _writerDal.Update(t);
        }
    }
}
