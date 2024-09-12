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
    public class GenreConManager : IGenreConService
    {
        public IGenreConDal _genreCon;

        public GenreConManager(IGenreConDal genreCon)
        {
            _genreCon = genreCon;
        }

        public List<GenreCon> GetList()
        {
            throw new NotImplementedException();
        }

        public List<int> GetListCategoryMovies(int id)
        {
            return _genreCon.GetListCategoryMovies(id);
        }

        public List<int> GetListDontCategoryMovies(int id)
        {
            return _genreCon.GetListDontCategoryMovies(id);
        }

        public List<int> GetListMoviesCategory(int id)
        {
            return _genreCon.GetListMoviesCategory(id);
        }

        public void TAdd(GenreCon t)
        {
            _genreCon.Insert(t);
        }

        public void TDelete(GenreCon t)
        {
            _genreCon.Delete(t);
        }

        public GenreCon TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(GenreCon t)
        {
            throw new NotImplementedException();
        }
    }
}
