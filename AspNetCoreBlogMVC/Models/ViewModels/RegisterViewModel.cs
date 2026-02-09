using System.ComponentModel.DataAnnotations;

namespace AspNetCoreBlogMVC.Models.ViewModels
{
    public class RegisterViewModel
    {
		[Required]
		public string Username { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(6, ErrorMessage = "Password has to be at least 6 characters")]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$",ErrorMessage = "Password harus mengandung minimal satu huruf besar dan satu simbol.")]
		public string Password { get; set; }
	}
}
