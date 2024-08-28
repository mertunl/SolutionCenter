using EntityLayer.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validator
{
    public class ApplicationValidator : AbstractValidator<Application>
    {
        public ApplicationValidator()
        {
            RuleFor(x=> x.Degree).NotEmpty().WithMessage("Lisans ismi boş bırakılamaz");
            RuleFor(x => x.Degree).MinimumLength(2).WithMessage("Lisans ismi en az 2 karakter olmalıdır");
            RuleFor(x => x.Degree).MaximumLength(50).WithMessage("Lisans ismi en fazla 50 karakter olmalıdır");
            RuleFor(x => x.Experience).NotEmpty().WithMessage("Tecrübe Yılı Boş Bırakılamaz");
            RuleFor(x => x.Experience).InclusiveBetween(0, 50).WithMessage("0-50 arası olmalıdır");
        }
    }
}
