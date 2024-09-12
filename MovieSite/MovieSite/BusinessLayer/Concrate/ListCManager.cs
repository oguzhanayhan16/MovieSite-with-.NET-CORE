using BusinessLayer.Absract;
using DataAccessLayer.Abstact;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class ListCManager : IListCService
    {
        IListCDal _listCDal;

        public ListCManager(IListCDal listCDal)
        {
            _listCDal = listCDal;
        }

        public List<ListC> GetList()
        {
           return _listCDal.GetListAll();
        }

        public void TAdd(ListC t)
        {
             _listCDal.Insert(t);
        }

        public void TDelete(ListC t)
        {
            _listCDal.Delete(t);
        }

        public ListC TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ListC t)
        {
            _listCDal.Update(t);
        }
    }
}
