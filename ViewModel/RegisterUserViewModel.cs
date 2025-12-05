using System.ComponentModel.DataAnnotations;

namespace FirstProject.ViewModel
{
	public class RegisterUserViewModel
	{
		public string UserName { get; set; } = null!;

		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Compare("Password")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; } = null!;

		public string? Address { get; set; }
	}
}
