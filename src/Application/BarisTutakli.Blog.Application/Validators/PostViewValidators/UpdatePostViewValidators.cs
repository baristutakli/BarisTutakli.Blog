using BarisTutakli.Blog.Application.ViewModels.PostViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Validators.PostViewValidators
{
    public class UpdatePostViewValidators : AbstractValidator<UpdatePostModel>
    {
        public UpdatePostViewValidators()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(vm => vm.Title).MaximumLength(150).NotEmpty().NotNull();
            RuleFor(vm => vm.Summary).MaximumLength(300);
            RuleFor(vm => vm.Body).NotNull().NotEmpty();
          
        }
    }
}


