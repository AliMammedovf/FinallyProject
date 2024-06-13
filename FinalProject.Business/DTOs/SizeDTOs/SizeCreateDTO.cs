using FinalProject.Business.DTOs.SizeDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.SizeDTOs;

public  class SizeCreateDTO
{
    public string Name { get; set; }


}

public class SizeCreateDTOValidator : AbstractValidator<SizeCreateDTO>
{
    public SizeCreateDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .NotNull().WithMessage("Name cannot be null!")
            .MaximumLength(10).WithMessage("Length should be max 10!");
    }
}

