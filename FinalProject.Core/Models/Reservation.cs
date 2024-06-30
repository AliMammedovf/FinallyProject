namespace FinalProject.Core.Models;

public class Reservation:BaseEntity
{
	public string Email { get; set; } = null!;
	public string Phone { get; set; } = null!;

	public int TableId { get; set; }

	public Table Table { get; set; }

    public string Comments { get; set; }

    public DateTime? StartDate { get; set; }

	public DateTime? EndDate { get; set; }

	public AppUser? User { get; set; }
}
