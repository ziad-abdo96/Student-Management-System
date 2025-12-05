using System.ComponentModel.DataAnnotations;

namespace FirstProject.ViewModel
{
	public class RoleViewModel
	{
		[Display(Name = "Role Name")]
		public string RoleName { get; set; }

	}
}
