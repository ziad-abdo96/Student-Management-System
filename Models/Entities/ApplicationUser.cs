using Microsoft.AspNetCore.Identity;

namespace FirstProject.Models.Entities
{
	public class ApplicationUser:IdentityUser
	{
		public string? Address { get; set; }
	}
}
