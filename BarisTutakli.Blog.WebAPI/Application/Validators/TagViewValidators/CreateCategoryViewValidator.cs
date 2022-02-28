
using BarisTutakli.Blog.WebAPI.Application.ViewModels.TagViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Application.Validators.CategoryViewValidators
{
    public class CreateTagViewValidator : AbstractValidator<CreateTagModel>
    {
        public CreateTagViewValidator()
        {
            RuleFor(vm => vm.Title).NotNull().NotEmpty().MaximumLength(75);
            RuleFor(vm => vm.Body).NotNull().NotEmpty().MaximumLength(300);
    }
    }
}
