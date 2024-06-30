using FinalProject.Business.DTOs.AboutSliderDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.PizzaMenyuDTOs;

public class PizzaMenyuCreateDTO
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public IFormFile ImageFile { get; set; } = null!;
}

public class PizzaMenyuCreateDTOValidator : AbstractValidator<PizzaMenyuCreateDTO>
{
    public PizzaMenyuCreateDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty!")
            .NotNull().WithMessage("Title cannot be null!")
            .MaximumLength(30).WithMessage("Length should be max 30!");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .NotNull().WithMessage("Description cannot be null!")
            .MaximumLength(30).WithMessage("Length should be max 70!");
        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.Price <= 0)
            {
                context.AddFailure("Price", "Price should be min 1!");
            }

        });
    }
}


