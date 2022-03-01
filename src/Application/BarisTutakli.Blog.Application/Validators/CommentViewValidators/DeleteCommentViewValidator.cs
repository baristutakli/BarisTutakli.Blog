using BarisTutakli.Blog.Application.ViewModels.CommentViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Validators.CommentViewValidators
{
    public class DeleteCommentViewValidator : AbstractValidator<DeleteCommentModel>
    {
        public DeleteCommentViewValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}
