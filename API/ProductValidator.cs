using API.DTOs;
using Entities;
using FluentValidation;

namespace API;

public class ProductValidator : AbstractValidator<PostProductDTO>
{
    public ProductValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
    }
}