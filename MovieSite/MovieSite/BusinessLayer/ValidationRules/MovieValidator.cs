using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Film adını boş geçmeyiniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Film tanıtımını boş geçmeyiniz.");
            RuleFor(x => x.ReleaseDate).NotEmpty().WithMessage("Film yayınlanma tarihini boş geçmeyiniz.");
            RuleFor(x => x.RunningTime).NotEmpty().WithMessage("Film süresini boş geçmeyiniz.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url kısmını boş geçmeyiniz.");
          
        }
    }
    
    
}
