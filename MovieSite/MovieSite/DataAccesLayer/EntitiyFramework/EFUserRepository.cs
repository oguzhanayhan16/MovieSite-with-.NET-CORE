using DataAccesLayer.Abstact;
using DataAccessLayer.Abstact;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFUserRepository : GenericRepository<User>, IUserDal
    {
		public List<User> GetListWithCategoryByMovies(List<int> id)
		{
			using (var context = new Context())
			{
				return context.Users
					.Include(user => user.Comment)
					.Where(user => id.Contains(user.UserID))
					.ToList();
			}
		}

        public List<User> GetListWithClientDontSub()
        {
            using (var context = new Context())
            {
                DateTime dateThreshold = DateTime.Now.AddDays(-30);
                return context.Users
                              .Where(x => !x.PaidUntilDate.HasValue || x.PaidUntilDate.Value < dateThreshold)
                              .ToList();
            }

          

        }

        public List<User> GetListWithClientPaidSub()
        {

            using (var context = new Context())
            {
                DateTime dateThreshold = DateTime.Now.AddDays(-30);
                return context.Users.Where(x => x.PaidUntilDate.HasValue && x.PaidUntilDate >= dateThreshold).ToList();
            }

        }
    }
}
