using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstact
{
    public interface ICollectionDal:IGenericDal<Collection>
    {
        public Collection GetByCollection(int UserID,int MovieID);
    }
}
