using DataAccessLayer.Abstact;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFCollectionRepository : GenericRepository<Collection>, ICollectionDal
    {
        public Collection GetByCollection(int userID, int movieID)
        {
            using (var context = new Context())
            {
                var collection = context.Collections.FirstOrDefault(x => x.UserID == userID && x.MovieID == movieID);
                return collection;
            }
        }

    }
}
