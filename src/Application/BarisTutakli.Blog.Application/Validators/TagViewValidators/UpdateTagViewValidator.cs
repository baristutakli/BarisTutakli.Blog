
using BarisTutakli.Blog.Application.ViewModels.TagViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Validators.CategoryViewValidators
{
    public class UpdateTagViewValidator : AbstractValidator<UpdateTagModel>
    {
        public UpdateTagViewValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).NotNull();
            RuleFor(vm => vm.Title).NotNull().NotEmpty().MaximumLength(75);
            RuleFor(vm => vm.Body).NotNull().NotEmpty().MaximumLength(300);
    }
    }
}
