using System.ComponentModel.DataAnnotations;

namespace FirstProject.ViewModel
{
	public class LoginUserViewModel
	{
		[Required(ErrorMessage = "*")]
		public string UserName { get; set; } = null!;

		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Display(Name = "Remember Me!!")]
		public bool RemeberMe { get; set; }
	}
}
