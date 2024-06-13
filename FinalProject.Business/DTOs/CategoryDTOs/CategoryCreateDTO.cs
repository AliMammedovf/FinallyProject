using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.CategoryDTOs;

public class CategoryCreateDTO
{
    public string Name { get; set; }
}

public class CategoryCreateDTOValidator: AbstractValidator<CategoryCreateDTO>
{
    public CategoryCreateDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .NotNull().WithMessage("Name cannot be null!")
            .MaximumLength(20).WithMessage("Length should be max 20!");
    }
}

