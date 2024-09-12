using BusinessLayer.Absract;
using DataAccesLayer.Abstact;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> GetList()
        {
            return _roleDal.GetListAll();
        }

        public void TAdd(Role t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Role t)
        {
            throw new NotImplementedException();
        }

        public Role TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Role t)
        {
            throw new NotImplementedException();
        }
    }
}
