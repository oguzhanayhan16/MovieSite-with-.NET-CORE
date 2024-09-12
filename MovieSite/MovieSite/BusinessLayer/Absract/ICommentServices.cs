using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absract
{
	public interface ICommentServices : IGenericService<Comment>
    {
		void CommentAdd(Comment comment);
        public List<int> FindCommentUser(int id);
        public List<User> GetCommentUser(List<int> userID);
        List<Comment> GetList(int id);
        public List<int> FindCommentMovie(int id);
        public List<Movie> GetCommentMovie(List<int> movieID);


    }
}
