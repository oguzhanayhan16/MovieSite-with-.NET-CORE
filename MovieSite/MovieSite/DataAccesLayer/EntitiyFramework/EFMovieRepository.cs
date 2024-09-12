using DataAccessLayer.Abstact;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFMovieRepository : GenericRepository<Movie>, IMovieDal
    {
       

        public List<int> GetMovieIDsByListID(int listID)
        {
            using (var context = new Context())
            {
                // Belirli bir ListID'ye göre ListConnect tablosundan MovieID'leri al
                var movieIDs = context.ListConnects
                                      .Where(x => x.ListID == listID)
                                      .Select(x => x.MovieID)
                                      .ToList();

                return movieIDs;
            }
        }
        public List<Movie> GetMoviesByListID(int listID)
        {
            using (var context = new Context())
            {
                var movieIDs = GetMovieIDsByListID(listID);

                // MovieID'lerini kullanarak ilgili Movie nesnelerini al
                var movies = context.Movies
                                    .Where(m => movieIDs.Contains(m.MovieID))
                                    .ToList();

                return movies;
            }
        }

       
    }
}
