using BarisTutakli.Blog.Application.ViewModels.CommentViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Validators.CommentViewValidators
{
    public class UpdateCommentViewValidator : AbstractValidator<UpdateCommentModel>
    {
        public UpdateCommentViewValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(vm => vm.Title).NotNull().MaximumLength(100);
            RuleFor(vm => vm.Body).MaximumLength(500);
            RuleFor(vm => vm.Published == true);
        }
    }
}
