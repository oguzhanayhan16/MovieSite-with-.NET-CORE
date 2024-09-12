using BusinessLayer.Absract;
using DataAccesLayer.Abstact;
using DataAccessLayer.Abstact;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class HelpMessageManager : IHelpMessageService
    {

        IHelpMessageDal _help;

        public HelpMessageManager(IHelpMessageDal help)
        {
            _help = help;
        }

        public List<HelpMessage> GetList()
        {
           return _help.GetListAll();
        }

        public List<HelpMessage> GetListUserViewMessage(int id)
        {
            using (var c = new Context())
            {
                var user = c.HelpMessages
                              .Where(m => m.ReceiverID == id)
                              .ToList();
                return user;
            }
        }
        public List<HelpMessage> Take3GetList(List<HelpMessage> help)
        {
            return help.Take(3).ToList();

        }


        public List<HelpMessage> GetListAdminMessage()
        {
            using (var c = new Context())
            {
                    var user = c.HelpMessages
                                  .Where(m =>m.ReceiverID==4)
                                  .ToList();
                    return user;
            }
        }
        public List<int> GetListAdminMessageId()
        {
            using (var c = new Context())
            {
                var user = c.HelpMessages
                              .Where(m => m.ReceiverID == 4).Select(y=>y.UserID)
                              .ToList();
                return user;
            }
        }

        public List<int> GetSendingMessageByID()
        {
            using (var c = new Context())
            {
                var user = c.HelpMessages
                              .Where(m => m.UserID == 4).Select(y =>y.ReceiverID)
                              .ToList();
                return user;
            }
        }
        public List<HelpMessage> GetSendingMessageBy()
        {
            using (var c = new Context())
            {
                var user = c.HelpMessages
                              .Where(m => m.UserID == 4)
                              .ToList();
                return user;
            }
        }


        public HelpMessage GetListMessageByID(int id)
        {
            using (var c = new Context())
            {
                var user = c.HelpMessages.Where(m=>m.MessageID==id).FirstOrDefault();
                              
                            
                return user;
            }
        }



        public List<HelpMessage> GetList3Take()
        {
            return _help.GetListAll().Take(3).ToList();
        }
        public List<User> GetMessageUser(List<int> userID)
        {
            using (var c = new Context())
            {


                if (userID != null && userID.Any())
                {
                    var user = c.Users
                                  .Where(m => userID.Contains(m.UserID))
                                  .ToList();
                    return user;
                }
                else
                {
                    return new List<User>(); // veya null
                }
            }
        }
        public void TAdd(HelpMessage t)
        {
            _help.Update(t);
        }

        public void TDelete(HelpMessage t)
        {
            _help.Delete(t);
        }

        public HelpMessage TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(HelpMessage t)
        {
            throw new NotImplementedException();
        }

        public List<User> GetListHelpMessageByUser(List<int> id)
        {
            return _help.GetListHelpMessageByUser(id);
        }
    }
}
