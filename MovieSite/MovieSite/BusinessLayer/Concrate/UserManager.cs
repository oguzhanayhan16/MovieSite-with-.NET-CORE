using BusinessLayer.Absract;
using DataAccesLayer.Abstact;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    
    public class UserManager : IUserService
    {
        IUserDal IuserDal;
        Context c = new Context();
        public UserManager(IUserDal ıuserDal)
        {
            IuserDal = ıuserDal;
        }

        public List<User> GetList()
        {
            return c.Users.Where(u => u.Email != null).ToList();
        }
        public List<string> GetAllEmails()
        {
            var email = c.Users.Where(u => u.Email != null).ToList();
            var mail = email.Select(u => u.Email).ToList();
            return mail;
        }

        public List<string> GetAllPass()
        {
            var pass = c.Users.Where(u => u.Password != null).ToList();
            var password = pass.Select(u => u.Password).ToList();
            return password;
        }

        public User getUser(int id)
        {
            return c.Set<User>().FirstOrDefault(x => x.UserID == id);
        }
        public User getUserEmail(string email)
        {
            return c.Set<User>().FirstOrDefault(x => x.Email == email);
        }

        public void TAdd(User t)
        {
            IuserDal.Insert(t);
        }

        public void TDelete(User t)
        {
            IuserDal.Delete(t);
        }

        public User TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(User t)
        {
            // Öncelikle güncellenen kullanıcıyı veritabanından alıyoruz
            var existingUser = c.Users.FirstOrDefault(u => u.Email == t.Email);

            // Eğer kullanıcı mevcutsa güncelleme yapılıyor
            if (existingUser != null)
            {
                existingUser.LastLogin = t.LastLogin;
                existingUser.Logged = t.Logged;
                c.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Güncellenmek istenen kullanıcı bulunamadı.");
            }
        }

        public List<User> GetListWithCategoryByMovies(List<int> id)
        {
            return IuserDal.GetListWithCategoryByMovies(id);
        }

        public List<User> GetListWithClientDontSub()
        {
           return IuserDal.GetListWithClientDontSub();
        }

        public List<User> GetListWithClientPaidSub()
        {
            return IuserDal.GetListWithClientPaidSub();
        }
    }
}
