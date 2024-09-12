using DataAccesLayer.Abstact;
using DataAccessLayer.Abstact;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntitiyFramework
{
    public class EFListConnectRepository : GenericRepository<ListConnect>, IListConnectDal
    {
        public List<int> GetListMovies(int id)
        {
           
                using (var context = new Context())
                {
                    return context.ListConnects.Where(x => x.ListID == id).Select(y => y.MovieID).ToList();

                }
        }

        public List<int> GetListMoviesList(int id)
        {
            using (var context = new Context())
            {
                return context.ListConnects.Where(x => x.MovieID == id).Select(y => y.ListID).ToList();

            }
        }
    }
}
