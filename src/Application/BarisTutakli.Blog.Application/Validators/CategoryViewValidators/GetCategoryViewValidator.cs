using BarisTutakli.Blog.Application.Models.CategoryModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Validators.CategoryViewValidators
{
    public class GetCategoryViewValidator : AbstractValidator<GetCategoryTitleModel>
    {
        public GetCategoryViewValidator()
        {
            RuleFor(vm => vm.Title).NotNull().NotEmpty().MaximumLength(50);
    }
    }
}
