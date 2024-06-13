using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.ProductDTOs;

public class ProductCreateDTO
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AdditionalInfo { get; set; } = null!;
    public bool IsAvialable { get; set; }
    public double Price { get; set; }

    public int CategoryId { get; set; }

    public int FlavourId { get; set; }

    public IFormFile ImageFile { get; set; }= null!;
}

public class ProductCreateDTOValidator: AbstractValidator<ProductCreateDTO>
{
    public ProductCreateDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty!")
            .NotNull().WithMessage("Title cannot be null!")
            .MaximumLength(50).WithMessage("Length should be max 50!");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .NotNull().WithMessage("Description cannot be null!")
            .MaximumLength(200).WithMessage("Length should be max 200!");
        RuleFor(x => x.AdditionalInfo)
           .NotEmpty().WithMessage("AdditionalInfo cannot be empty!")
           .NotNull().WithMessage("AdditionalInfo cannot be null!")
           .MaximumLength(100).WithMessage("Length should be max 100!");

        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.Price <= 0)
            {
                context.AddFailure("Price", "Price should be min 1!");
            }

        });
    }
}