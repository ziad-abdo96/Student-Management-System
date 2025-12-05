using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models.Entities
{
	public class Employee
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		[MinLength(3)]
		public string Name { get; set; } = null!;  

		public int Salary { get; set; }

		public string JobTitle { get; set; } = null!;

		public string ImageURL { get; set; } = null!;

		public string? Address { get; set; }

		[Display(Name="Department")]
		public int DepartmentID { get; set; }

		public Department Department { get; set; } = null!;
	}
}
