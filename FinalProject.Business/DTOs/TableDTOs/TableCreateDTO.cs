using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.TableDTOs;

public class TableCreateDTO
{
	public string Title { get; set; }

	public decimal Price { get; set; }

	public int Seats { get; set; }
}


public class  TableCreateDTOValidator: AbstractValidator<TableCreateDTO>
{
	public TableCreateDTOValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title cannot be empty!")
			.NotNull().WithMessage("Title cannot be empyt!")
			.MaximumLength(50).WithMessage("Length should be max 50! ");


		RuleFor(x => x).Custom((x, context) =>
		{
			if (x.Price <= 0)
			{
				context.AddFailure("Price", "Price should be min 1!");
			}

		});

		RuleFor(x => x).Custom((x, context) =>
		{
			if (x.Seats <= 1)
			{
				context.AddFailure("Seats", "Seats should be min 1!");
			}

		});

	}
}
