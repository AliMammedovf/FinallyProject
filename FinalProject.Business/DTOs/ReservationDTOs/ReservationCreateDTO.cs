using FinalProject.Business.DTOs.TableDTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinalProject.Business.DTOs.ReservationDTOs;

public class ReservationCreateDTO
{
	public string Email { get; set; } = null!;
	public string Phone { get; set; } = null!;
	public int TableId { get; set; }

    public FinalProject.Core.Models.Table? Table { get; set; }


    public string Comments { get; set; }

	public DateTime? StartDate { get; set; }
	public DateTime? EndDate { get; set; }

}

public class ReservationCreateDTOValidator : AbstractValidator<ReservationCreateDTO>
{
	public ReservationCreateDTOValidator()
	{
		RuleFor(x => x.TableId)
			.NotEmpty().WithMessage("TableId bos ola bilmez!")
			.NotNull().WithMessage("TableId null ola bilmez!");

		RuleFor(x => x.StartDate)
			.NotEmpty().WithMessage("StartDate bos ola bilmez!")
			.NotNull().WithMessage("StartDate null ola bilmez!");

		RuleFor(x => x.EndDate)
			.NotEmpty().WithMessage("EndDate bos ola bilmez!")
			.NotNull().WithMessage("EndDate null ola bilmez!");
	}
}
