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
    public class ListManager : IListCService
    {
        IListCDal _listDal;

        public ListManager(IListCDal listDal)
        {
            _listDal = listDal;
            
        }

        public List<ListC> GetList()
        {
           return _listDal.GetListAll();
        }
        public List<ListC> Take3GetList()
        {
            return _listDal.GetListAll().Take(1).ToList();

        }


        public void TAdd(ListC t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ListC t)
        {
            throw new NotImplementedException();
        }

        public ListC TGetByID(int id)
        {
           return _listDal.GetByID(id);
        }

        public void TUpdate(ListC t)
        {
            throw new NotImplementedException();
        }
    }
}
