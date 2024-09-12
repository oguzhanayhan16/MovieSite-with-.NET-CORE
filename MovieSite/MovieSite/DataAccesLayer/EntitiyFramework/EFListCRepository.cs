using DataAccessLayer.Abstact;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntitiyFramework
{
    public class EFListCRepository: GenericRepository<ListC>, IListCDal
    {
    }
}
