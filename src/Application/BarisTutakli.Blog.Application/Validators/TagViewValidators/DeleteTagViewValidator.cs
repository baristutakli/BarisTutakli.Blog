
using BarisTutakli.Blog.Application.Models.TagModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Validators.CategoryViewValidators
{
    public class DeleteTagViewValidator : AbstractValidator<DeleteTagModel>
    {
        public DeleteTagViewValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).NotNull();
    }
    }
}
