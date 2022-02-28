﻿using BarisTutakli.Blog.WebAPI.Application.ViewModels.CategoryViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Application.Validators.CategoryViewValidators
{
    public class UpdateCategoryViewValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryViewValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).NotNull();
            RuleFor(vm => vm.Title).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(vm => vm.Description).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(vm => vm.MetaTitle).NotNull().NotEmpty().MaximumLength(50);
    }
    }
}
