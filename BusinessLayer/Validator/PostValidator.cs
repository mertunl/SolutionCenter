using EntityLayer.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validator
{
	public class PostValidator : AbstractValidator<Post>
	{
        public PostValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x=>x.Title).MinimumLength(10).WithMessage("10 karakterden az olamaz");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("100 karaterden fazla olamaz");
            RuleFor(x=>x.Content).Length(20,500).WithMessage("20-500 karakter arasında olmalıdır");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Boş Bırakılamaz");
			RuleFor(x => x.Categories).NotEmpty().WithMessage("Boş Bırakılamaz");
		}
    }
}
