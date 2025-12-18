using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models.Entities
{
	public class Department
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Department name is required")]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
		[Display(Name = "Department Name")]
		public string Name { get; set; } = string.Empty;

		[StringLength(100, ErrorMessage = "Manager name cannot exceed 100 characters")]
		[Display(Name = "Manager Name")]
		public string? ManagerName { get; set; } 
		public List<Instructor> Instructors { get; set; } = new List<Instructor>();
		public List<Trainee> Trainees { get; set; } = new List<Trainee>();
		public List<Course> Courses { get; set; } = new List<Course>();

		public bool IsDeleted { get; set; } = false;
		public DateTime? DeletedAt { get; set; }
	}
}