using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models.Entities
{
	public class Department
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		[MinLength(3)]
		public string Name { get; set; } = null!;

		[MaxLength(30)]
		[MinLength(3)]
		public string? ManagerName { get; set; }

		public List<Instructor> Instructors { get; set; } = null!;
		
		public List<Trainee> Trainees { get; set; } = null!;
		
		public List<Course> Courses { get; set; } = null!;
	}
}

