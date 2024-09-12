using EntityLayer.Concrete;

namespace MovieSite.Models
{
    public class PaymentViewModel
	{

        public List<Subscription> Subscriptions { get; set; }
        public User User { get; set; }
        public bool  CanProceedWithPayment  { get; set; }
    }
}
