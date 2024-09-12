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
    public class CollectionManager : ICollectionServices
    {
        public ICollectionDal _collectionDal;

        public CollectionManager(ICollectionDal collectionDal)
        {
            _collectionDal = collectionDal;
        }

        public Collection GetByCollection(int UserID, int MovieID)
        {
           return _collectionDal.GetByCollection(UserID, MovieID);
        }

        public List<Collection> GetList()
        {
            return _collectionDal.GetListAll();
        }

        public void TAdd(Collection t)
        {
           _collectionDal.Insert(t);
        }

        public void TDelete(Collection t)
        {
            throw new NotImplementedException();
        }

        public Collection TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Collection t)
        {
            _collectionDal.Update(t);
        }
    }
}
