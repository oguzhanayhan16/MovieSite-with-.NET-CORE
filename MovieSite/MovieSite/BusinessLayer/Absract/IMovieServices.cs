using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absract
{
	public interface IMovieServices : IGenericService<Movie>
    {
        List<Movie> GetMoviesByListID(List<int> listIds);
    }
}
