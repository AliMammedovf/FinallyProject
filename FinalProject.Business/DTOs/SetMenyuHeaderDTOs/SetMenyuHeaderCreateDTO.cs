using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.SetMenyuHeaderDTOs;

public class SetMenyuHeaderCreateDTO
{
	public string Title { get; set; } = null!;

	public string Description { get; set; } = null!;

	public IFormFile ImageFile { get; set; } 
}

public class SetMenyuHeaderCreateDTOValidator : AbstractValidator<SetMenyuHeader>
{
	public SetMenyuHeaderCreateDTOValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title cannot be empty!")
			.NotNull().WithMessage("Title cannot be null!")
			.MaximumLength(100).WithMessage("Length should be max 100!");

		RuleFor(x => x.Description)
			.NotEmpty().WithMessage("Description cannot be empty!")
			.NotNull().WithMessage("Description cannot be null!")
			.MaximumLength(250).WithMessage("Length should be max 250!");

	}
}
