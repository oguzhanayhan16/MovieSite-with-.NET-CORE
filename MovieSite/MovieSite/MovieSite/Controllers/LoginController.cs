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
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


namespace MovieSite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager(new EFUserRepository());
        Context c = new Context();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            LoginValidator validator = new LoginValidator();
            ValidationResult results = validator.Validate(user);

            if (results.IsValid)
            {
                string hashedPassword = HashPassword(user.Password);
                var values = c.Users.Include(u => u.Role)
                                    .FirstOrDefault(x => x.Email == user.Email && x.Password == hashedPassword);

                if (values != null)
                {
                    // Son giriş zamanını güncelle
                    values.LastLogin = DateTime.Now;
                    values.Logged = true;
                    userManager.TUpdate(values);

                    // Kullanıcı claimlerini oluşturma
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, values.Email),
                new Claim(ClaimTypes.Role, values.Role.RoleName) // Rol bilgisini ekliyoruz
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Role göre yönlendirme
                    if (values.RoleID == 3)
                    {
                        return RedirectToAction("LogMovie", "Movie");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Client", new { area = "Admin" });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bu e-posta adresiniz ya da şifreniz yanlıştır.");
                }
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View(user);
        }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            var userEmail = User.Identity.Name; 
            var user = c.Users.FirstOrDefault(u => u.Email == userEmail);

            if (user != null)
            {
                user.Logged = false;  
                userManager.TUpdate(user);  
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Movie");
        }
		public IActionResult AccessDenied()
		{
			return View();
		}
	}


}
