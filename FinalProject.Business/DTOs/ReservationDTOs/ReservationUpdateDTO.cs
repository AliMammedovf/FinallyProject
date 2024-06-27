using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.ReservationDTOs;

public class ReservationUpdateDTO
{
	public int Id { get; set; }
	public int ProductId { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public bool? IsDeleted { get; set; }
}

public class ReservationUpdateDTOValidator : AbstractValidator<ReservationUpdateDTO>
{
	public ReservationUpdateDTOValidator()
	{
		RuleFor(x => x.ProductId)
			 .NotEmpty().WithMessage("RoomId bos ola bilmez!")
			 .NotNull().WithMessage("RoomId null ola bilmez!");

		RuleFor(x => x.StartDate)
			.NotEmpty().WithMessage("StartDate bos ola bilmez!")
			.NotNull().WithMessage("StartDate null ola bilmez!");

		RuleFor(x => x.EndDate)
			.NotEmpty().WithMessage("EndDate bos ola bilmez!")
			.NotNull().WithMessage("EndDate null ola bilmez!");


	}
}
