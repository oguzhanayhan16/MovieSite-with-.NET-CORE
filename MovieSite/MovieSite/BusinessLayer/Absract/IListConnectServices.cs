using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absract
{
	public interface IListConnectServices:IGenericService<ListConnect>
	{
        public List<int> GetListMoviesList(int id);
        public List<int> GetListMovies(int id);

    }
}
