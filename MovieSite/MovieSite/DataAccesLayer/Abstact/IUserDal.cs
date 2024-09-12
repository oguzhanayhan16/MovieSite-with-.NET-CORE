using DataAccessLayer.Abstact;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstact
{
    public interface IUserDal: IGenericDal<User>
    {
		List<User> GetListWithCategoryByMovies(List<int> id);

        List<User> GetListWithClientPaidSub();
            
        List<User> GetListWithClientDontSub();
    }
}
