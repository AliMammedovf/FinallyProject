using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class ResetPasswordVm
    {
        public string Email { get; set; }

        public string Token { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }


    }
}
