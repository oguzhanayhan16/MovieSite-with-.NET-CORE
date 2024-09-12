using DataAccessLayer.Repositories;
using DataAccessLayer.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Concrate;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFGenreConRepository : GenericRepository<GenreCon>, IGenreConDal
    {

        public List<int> GetListCategoryMovies(int id)
        {
            using (var context = new Context())
            {
                return context.GenreCons.Where(x=>x.GenreID == id).Select(y=>y.MovieID).ToList();
                
            }
        }

        public List<int> GetListDontCategoryMovies(int id)
        {
            using (var context = new Context())
            {
                return context.GenreCons.Where(x => x.GenreID == id).Select(y => y.MovieID).ToList();

            }
        }



        public List<int> GetListMoviesCategory(int id)
        {
            using (var context = new Context())
            {
                return context.GenreCons.Where(x => x.MovieID == id).Select(y => y.GenreID).ToList();

            }
        }





    }
}
