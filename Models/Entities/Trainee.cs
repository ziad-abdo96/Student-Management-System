using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models.Entities
{
	public class Trainee
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Trainee name is required")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
		public string Name { get; set; } = string.Empty;

		[StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
		[Display(Name = "Profile Image")]
		public string? ImageURL { get; set; }

		[StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
		public string? Address { get; set; }

		[StringLength(5, ErrorMessage = "Grade cannot exceed 5 characters")]
		public string? Grade { get; set; }

		[Required(ErrorMessage = "Please select a department")]
		[Display(Name = "Department")]
		public int DepartmentId { get; set; }

		public Department? Department { get; set; }

		public List<CrsResult> CrsResults { get; set; } = new List<CrsResult>();

		public bool IsDeleted { get; set; } = false;

		public DateTime? DeletedAt { get; set; }
	}
}