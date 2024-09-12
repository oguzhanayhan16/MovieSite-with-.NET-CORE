using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class LoginValidator : AbstractValidator<User>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresinizi boş geçemessiniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrenizi boş geçemessiniz.");
        }
    }
}
