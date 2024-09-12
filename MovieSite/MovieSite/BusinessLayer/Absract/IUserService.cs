using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absract
{
    public interface IUserService : IGenericService<User>
    {
		List<User> GetListWithCategoryByMovies(List<int> id);
        public List<User> GetListWithClientDontSub();
        public List<User> GetListWithClientPaidSub();
    }
}
