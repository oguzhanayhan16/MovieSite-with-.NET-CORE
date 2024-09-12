using DataAccesLayer.Abstact;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntitiyFramework
{
    public class EFRatingRepository :GenericRepository<Rating>, IRatingDal
    {
    }
}
