using BusinessLayer.Concrate;
using DataAccesLayer.EntitiyFramework;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    [AllowAnonymous]
    public class PaymentController : Controller
    {

        SubscriptionManager sm = new SubscriptionManager(new EFSubscriptionRepository());
        UserManager um = new UserManager(new EFUserRepository());
        Context c = new Context();
        public IActionResult Index(int userID)
        {
            var values = sm.GetList();
            ViewBag.id = userID;
            return View(values);
        }


        public IActionResult Payment(int subscriptionId, int userID)
        {
            var value = c.Subscriptions
                         .Where(x => x.SubscriptionID == subscriptionId)
                         .Select(y => y.Money)
                         .FirstOrDefault();

            var user = c.Users.FirstOrDefault(x => x.UserID == userID);
            bool canProceedWithPayment = true;
           
            if (user != null)
            {
                double remainingDays = (DateTime.Now -user.PaidUntilDate.Value).TotalDays+29;

                if (user.PaidUntilDate != null && (DateTime.Now - user.PaidUntilDate.Value).TotalDays < 30)
                {
                    ViewBag.ErrorMessage = $"Zaten bir üyeliğiniz bulunmaktadır. Üyeliğinizin bitimine {Math.Ceiling(remainingDays)} gün kalmıştır. Lütfen üyeliğiniz sonlandığında tekrar deneyiniz.";
                    canProceedWithPayment = false;
                }
                else
                {
                    user.PaidUntilDate = DateTime.Now;
                    c.SaveChanges(); // Veritabanında değişiklikleri kaydedin
                }
            }

            var viewModel = new PaymentViewModel
            {
                Subscriptions = c.Subscriptions.ToList(),
                User = user,
                CanProceedWithPayment = canProceedWithPayment
            };

            ViewBag.id = value;
            ViewBag.UserID = userID;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PAY()
        {
            return RedirectToAction("LogMovie", "Movie");
        }


    }
}
