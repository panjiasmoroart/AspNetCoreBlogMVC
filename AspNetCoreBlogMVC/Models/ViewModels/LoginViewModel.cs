using System.ComponentModel.DataAnnotations;

namespace AspNetCoreBlogMVC.Models.ViewModels
{
    public class LoginViewModel
    {
		// Server Side Validation 
		[Required]
		public string Username { get; set; }

		[Required]
		[MinLength(6, ErrorMessage = "Password has to be at least 6 characters")]
		public string Password { get; set; }

		public string? ReturnUrl { get; set; }
	}
}
