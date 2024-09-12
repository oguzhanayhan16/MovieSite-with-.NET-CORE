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
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<int> FindCommentUser(int id)
        {
            using (var context = new Context())
            {
                return context.Comments.Where(x => x.MovieID == id).Select(y => y.UserID).ToList();

            }
        }
        public List<int> FindCommentMovie(int id)
        {
            using (var context = new Context())
            {
                return context.Comments.Where(x => x.UserID == id).Select(y => y.MovieID).ToList();

            }
        }
        public List<User> GetCommentUser(List<int> userID)
        {
            using (var c = new Context())
            {


                if (userID != null && userID.Any())
                {
                    var user = c.Users
                                  .Where(m => userID.Contains(m.UserID))
                                  .ToList();
                    return user;
                }
                else
                {
                    // movieIDs null veya boş ise uygun bir işlem yapın
                    return new List<User>(); // veya null
                }
            }
        }
        public List<Movie> GetCommentMovie(List<int> movieID)
        {
            using (var c = new Context())
            {


                if (movieID != null && movieID.Any())
                {
                    var user = c.Movies
                                  .Where(m => movieID.Contains(m.MovieID))
                                  .ToList();
                    return user;
                }
                else
                {
                    // movieIDs null veya boş ise uygun bir işlem yapın
                    return new List<Movie>(); // veya null
                }
            }
        }
    }
}
