using FirstProject.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace FirstProject.ViewModel
{
	public class EmpWithDepartListViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public int Salary { get; set; }

		public string JobTitle { get; set; } = null!;

		public string ImageURL { get; set; } = null!;

		public string? Address { get; set; }

		[Display(Name="Department")]
		public int DepartmentID { get; set; }

		public Department Department { get; set; } = null!;

		public List<Department> Departments { get; set; } = null!;
	}
}
