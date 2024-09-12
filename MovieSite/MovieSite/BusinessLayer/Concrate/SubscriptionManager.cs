using BusinessLayer.Absract;
using DataAccesLayer.Abstact;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class SubscriptionManager : ISubscriptionService
    {
        ISubscriptionDal _subDal;

        public SubscriptionManager(ISubscriptionDal subDal)
        {
            _subDal = subDal;
        }

     

        public List<Subscription> GetList()
        {
            return _subDal.GetListAll();
        }

        public void TAdd(Subscription t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Subscription t)
        {
            throw new NotImplementedException();
        }

        public Subscription TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Subscription t)
        {
            throw new NotImplementedException();
        }
    }
}
