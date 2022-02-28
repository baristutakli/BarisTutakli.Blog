
using BarisTutakli.Blog.WebAPI.Application.ViewModels.TagViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Application.Validators.CategoryViewValidators
{
    public class DeleteTagViewValidator : AbstractValidator<DeleteTagModel>
    {
        public DeleteTagViewValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).NotNull();
    }
    }
}
