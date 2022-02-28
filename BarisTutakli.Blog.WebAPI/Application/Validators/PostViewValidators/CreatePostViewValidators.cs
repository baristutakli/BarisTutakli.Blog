using BarisTutakli.Blog.WebAPI.Application.ViewModels.PostViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Application.Validators.PostViewValidators
{
    public class CreatePostViewValidators : AbstractValidator<CreatePostModel>
    {
        public CreatePostViewValidators()
        {
            RuleFor(vm => vm.Title).MaximumLength(150).NotEmpty().NotNull();
            RuleFor(vm => vm.Summary).MaximumLength(300);
            RuleFor(vm => vm.Body).NotNull().NotEmpty();
            RuleFor(vm => vm.Categories).NotEmpty().NotNull();
            RuleFor(vm => vm.Tags).NotEmpty().NotNull();
        }
    }
}


