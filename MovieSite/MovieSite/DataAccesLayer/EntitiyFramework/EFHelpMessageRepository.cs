using DataAccesLayer.Abstact;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntitiyFramework
{
    public class EFHelpMessageRepository :GenericRepository<HelpMessage>,IHelpMessageDal
    {

   
        public List<User> GetListHelpMessageByUser(List<int> id)
        {
            using (var context = new Context())
            {
                return context.Users
                    .Include(user => user.HelpMessage)
                    .Where(user => id.Contains(user.UserID))
                    .ToList();
            }
        }

    }
}
