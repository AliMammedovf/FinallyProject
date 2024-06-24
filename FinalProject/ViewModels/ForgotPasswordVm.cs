using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class ForgotPasswordVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
