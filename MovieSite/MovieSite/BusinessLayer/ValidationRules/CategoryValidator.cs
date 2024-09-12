using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Genre>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.GenreName).NotEmpty().WithMessage("Category alanı boş geçilemez.");
        }
    }
}
