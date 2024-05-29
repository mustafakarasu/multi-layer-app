﻿using FluentValidation;
using MultiLayer.Core.DTOs;

namespace MultiLayer.Service.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Price)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            
            RuleFor(x => x.Stock)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
    }
}
