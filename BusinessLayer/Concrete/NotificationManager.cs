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
    public class NotificationManager : INotificationService
    {
        public INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void AddT(Notification t)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(Notification t)
        {
            throw new NotImplementedException();
        }

        public Notification GetByIdT(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetListT()
        {
            return _notificationDal.GetListAll();
        }

        public void UpdateT(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
