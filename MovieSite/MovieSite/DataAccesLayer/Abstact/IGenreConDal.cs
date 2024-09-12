using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstact
{
    public interface IGenreConDal : IGenericDal<GenreCon>
    {
        public List<int> GetListCategoryMovies(int id);

        public List<int> GetListMoviesCategory(int id);
        public List<int> GetListDontCategoryMovies(int id);


    }
}
