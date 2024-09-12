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
    public class GenreManager : IGenreService
    {
        IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public List<Genre> GetList()
        {
            return _genreDal.GetListAll();
        }

        public Genre GetListByID(int id)
        {
            using (var c = new Context())
            {
                return c.Genres.Where(x=>x.GenreID==id).FirstOrDefault();
            }
        }

        public List<Genre> Take3GetList()
        {
            return _genreDal.GetListAll().Take(3).ToList();

        }

        public void TAdd(Genre t)
        {
            _genreDal.Insert(t);
        }

        public void TDelete(Genre t)
        {
            _genreDal.Delete(t);
        }

        public Genre TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Genre t)
        {
           _genreDal.Update(t);
        }
    }
}
