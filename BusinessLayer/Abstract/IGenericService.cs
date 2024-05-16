using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void AddT(T t);
        void UpdateT(T t);
        void DeleteT(T t);
        List<T> GetListT();
        T GetByIdT(int id);
    }
}
