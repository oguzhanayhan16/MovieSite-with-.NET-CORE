using BusinessLayer.Absract;
using DataAccessLayer.Abstact;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class MovieManager : IMovieServices
    {

        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public List<Movie> GetList()
        {
           return _movieDal.GetListAll();
        }

        public List<Movie> GetMoviesByListID(List<int> listIds)
        {
            using (var c = new Context())
            {
                var movieIDs = c.ListConnects
                                .Where(x => listIds.Contains(x.ListID))
                                .Select(x => x.MovieID)
                                .ToList();

                if (movieIDs != null && movieIDs.Any())
                {
                    var movies = c.Movies
                                  .Where(m => movieIDs.Contains(m.MovieID))
                                  .ToList();
                    return movies;
                }
                else
                {
            
                    return new List<Movie>(); // veya null
                }
            }
        }

   



        public List<Movie> GetMoviesByListIDforCategory(List<int> movieIDs)
        {
            using (var c = new Context())
            {
                

                if (movieIDs != null && movieIDs.Any())
                {
                    var movies = c.Movies
                                  .Where(m => movieIDs.Contains(m.MovieID))
                                  .ToList();
                    return movies;
                }
                else
                {
        
                    return new List<Movie>(); // veya null
                }
            }
        }

        public List<Movie> GetMoviesByListIDfDontCategory(List<int> movieIDs)
        {
            using (var c = new Context())
            {
                

                if (movieIDs != null && movieIDs.Any())
                {
                    // Gelen ID'ler dışındaki filmleri seçmek için 'Contains' yerine 'Does not contain' kullanmalısınız.
                    var movies = c.Movies
                                  .Where(m => !movieIDs.Contains(m.MovieID))
                                  .ToList();
                    return movies;
                }
                else
                {
                    // movieIDs null veya boş ise uygun bir işlem yapın
                    return new List<Movie>(); // veya null
                }
            }

        }

        public List<Genre> GetCategoriesByListIDforMovies(List<int> movieIDs)
        {
            using (var c = new Context())
            {
            

                if (movieIDs != null && movieIDs.Any())
                {
                    var genres = c.Genres
                                  .Where(m => movieIDs.Contains(m.GenreID))
                                  .ToList();
                    return genres;
                }
                else
                {
                    // movieIDs null veya boş ise uygun bir işlem yapın
                    return new List<Genre>(); // veya null
                }
            }

        }

        public List<ListC> GetListByListIDforMovies(List<int> movieIDs)
        {
            using (var c = new Context())
            {


                if (movieIDs != null && movieIDs.Any())
                {
                    var list = c.ListCs
                                  .Where(m => movieIDs.Contains(m.ListID))
                                  .ToList();
                    return list;
                }
                else
                {
                    // movieIDs null veya boş ise uygun bir işlem yapın
                    return new List<ListC>(); // veya null
                }
            }

        }


        public void TAdd(Movie t)
        {
            _movieDal.Insert(t);
        }

        public void TDelete(Movie t)
        {
            _movieDal.Delete(t);
        }

        public Movie TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Movie t)
        {
            _movieDal.Update(t);
        }
    }
}
