using EntityLayer.Concrete;
using DataAccessLayer.Concrate;
using BusinessLayer.ValidationRules;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using DataAccessLayer.EntitiyFramework;
using BusinessLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace MovieSite.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        UserManager vm = new UserManager(new EFUserRepository());

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(User u)
        {
            {
                RegisterValidator validator = new RegisterValidator();
                ValidationResult results = validator.Validate(u);
                if (results.IsValid)
                {
                    if (vm.GetAllEmails().Any(email=>email == u.Email))
                    {
                        ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanılmaktadır.");
                        return View(u);
                    }


                    TempData["Email"] = u.Email; // Email'i TempData üzerinde sakla
                    return RedirectToAction("Register", "Register");

                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                return View();
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(User u)
        {
            Register2Validator validator = new Register2Validator();
            ValidationResult results = validator.Validate(u);
            if (results.IsValid)
            {
                // Kullanıcı şifresini hashle
                u.Password = HashPassword(u.Password);
                u.ConfrimPass = HashPassword(u.ConfrimPass);

                u.SubscriptionID = 1;
                string email = TempData["Email"] as string;
                u.Email = email;
                u.Username = "kullanıcı";
                u.Avatar = "/filmSitesi/filmsitesi/image/icons8-name-50.png";
                u.LastLogin= DateTime.Now;
                u.Logged = true;
                u.RoleID = 3;
                vm.TAdd(u);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,u.Email)

                    };
                var identity = new ClaimsIdentity(claims, "a");

                ClaimsPrincipal prin = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(prin);


                return RedirectToAction("LogMovie", "Movie");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        // Şifreyi hashleyen metot
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

}

