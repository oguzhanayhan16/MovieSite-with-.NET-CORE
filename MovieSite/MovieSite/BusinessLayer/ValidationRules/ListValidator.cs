using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ListValidator : AbstractValidator<ListC>
    {
        public ListValidator()
        {
            RuleFor(x => x.ListName).NotEmpty().WithMessage("List adınızı  boş geçemessiniz.");
        }
    }
}
