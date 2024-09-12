using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class Register2Validator : AbstractValidator<User>
    {
        public Register2Validator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsminizi boş geçemessiniz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisminizi boş geçemessiniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrenizi boş geçemessiniz.");
            RuleFor(x => x.ConfrimPass).NotEmpty().WithMessage("Şifre tekrarını boş geçemessiniz.");
            RuleFor(x => x.ConfrimPass).Equal(x => x.Password).WithMessage("Şifreleriniz aynı değildir.");
        }
    }
}
