using BusinessLayer.Absract;
using DataAccessLayer.Abstact;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrate
{
    public class CommentManager : ICommentServices
    {
        ICommentDal commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<int> FindCommentMovie(int id)
        {
            return commentDal.FindCommentMovie(id);
        }

        public List<int> FindCommentUser(int id)
        {
           return commentDal.FindCommentUser(id);
        }

        public List<Movie> GetCommentMovie(List<int> movieID)
        {
            return commentDal.GetCommentMovie(movieID);
        }

        public List<User> GetCommentUser(List<int> userID)
        {
            return commentDal.GetCommentUser(userID);
        }

        

        public List<Comment> GetList(int id)
        {
            return commentDal.GetListAll(x => x.MovieID == id);
        }
        public List<Comment> GetListCom(int id)
        {
            return commentDal.GetListAll(x => x.UserID == id);
        }


        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Comment t)
        {
            commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
           commentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
