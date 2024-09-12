using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstact
{
    public interface ICommentDal:IGenericDal<Comment>
    {

        public List<int> FindCommentUser(int id);
        public List<User> GetCommentUser(List<int> userID);

        public List<int> FindCommentMovie(int id);

        public List<Movie> GetCommentMovie(List<int> movieID);
    }
}
