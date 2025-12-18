using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models.Entities
{
	public class Employee
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Employee is required")]
		[StringLength(30, MinimumLength = 3, ErrorMessage = "Name must to between 3 and 30 characters")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Salary is required")]
		[Range(0, 1000000, ErrorMessage = "Salary must be between 0 and 1,000,000")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Salary { get; set; }

		[Required(ErrorMessage = "Job title is required")]
		[StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters")]
		[Display(Name = "Job Title")]
		public string JobTitle { get; set; } = string.Empty;

		[StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
		[Display(Name = "Profile Image")]
		public string? ImageURL { get; set; } 

		[StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
		public string? Address { get; set; }

		[Required(ErrorMessage = "Please select a department")]
		[Display(Name = "Department")]
		public int DepartmentId { get; set; }

		public Department Department { get; set; } = null!;
	}
}
