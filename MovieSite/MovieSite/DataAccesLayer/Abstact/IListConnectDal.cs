using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstact
{
    public interface IListConnectDal : IGenericDal<ListConnect>
    {
        public List<int> GetListMoviesList(int id);
        public List<int> GetListMovies(int id);

    }
}
