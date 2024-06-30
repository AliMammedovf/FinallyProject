using FinalProject.Business.DTOs.AboutSliderDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.AboutInfoDTOs;

public class AboutInfoCreateDTO
{

	public string Title { get; set; } = null!;

	public string? Description { get; set; }

	public string? ImageUrl { get; set; }

	public string FonUrl { get; set; }

	public IFormFile ImageFile { get; set; }

	public IFormFile? FonImage { get; set; }
}

public class AboutInfoCreateDTOValidator : AbstractValidator<AboutInfoCreateDTO>
{
	public AboutInfoCreateDTOValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title cannot be empty!")
			.NotNull().WithMessage("Title cannot be null!")
			.MaximumLength(100).WithMessage("Length should be max 100!");

		RuleFor(x => x.Description)
			.NotEmpty().WithMessage("Description cannot be empty!")
			.NotNull().WithMessage("Description cannot be null!")
			.MaximumLength(200).WithMessage("Length should be max 200!");

		

	}
}
