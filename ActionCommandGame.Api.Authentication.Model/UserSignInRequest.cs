using System.ComponentModel.DataAnnotations;

namespace ActionCommandGame.Api.Authentication.Model
{
	public class UserSignInRequest
	{
		[Required(ErrorMessage = "Please use a valid email")]
		public string? Email { get; set; }

        [Required(ErrorMessage = "Please use the correct password")]
        public string? Password { get; set; }
	}
}
