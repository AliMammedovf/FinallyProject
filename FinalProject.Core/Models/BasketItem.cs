namespace FinalProject.Core.Models;

    public class BasketItem:BaseEntity
{
	public string AppUserId { get; set; }
	public int ProductId { get; set; }

	public int SizeId { get; set; }

	public int FlavourId { get; set; }
	
	public int Count { get; set; }
	public Product Product { get; set; }
	public AppUser AppUser { get; set; }

	
}
