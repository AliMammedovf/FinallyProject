using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
	public class AdminLoginVm
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		
		[MaxLength(50)]
		public string? UserName { get; set; }

		[Required]
		[MinLength(8)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool IsPersistent { get; set; }
	}
}
