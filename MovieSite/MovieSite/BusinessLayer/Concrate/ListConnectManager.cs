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
    public class ListConnectManager : IListConnectServices
    {
        IListConnectDal _listDal;

        public ListConnectManager(IListConnectDal listDal)
        {
            _listDal = listDal;
        }

        public List<ListConnect> GetList()
        {
            return _listDal.GetListAll();
        }

        public List<int> GetListMovies(int id)
        {
            return _listDal.GetListMovies(id);
        }

        public List<int> GetListMoviesList(int id)
        {
            return _listDal.GetListMoviesList(id);
        }

        public void TAdd(ListConnect t)
        {
            _listDal.Insert(t);
        }

        public void TDelete(ListConnect t)
        {
            _listDal.Delete(t);
        }

        public ListConnect TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ListConnect t)
        {
            throw new NotImplementedException();
        }
    }
}
