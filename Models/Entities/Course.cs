using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models.Entities
{
	public class Course
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Course name is required")]
		[StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
		[Display(Name = "Course Name")]
		public string Name { get; set; } = null!;

		[Required(ErrorMessage = "Degree is required")]
		[Range(0, 100, ErrorMessage = "Degree must be between 0 and 100")]
		public int Degree { get; set; }

		[Required(ErrorMessage = "Hours is required")]
		[Range(1, 500, ErrorMessage = "Hours must be between 1 and 500")]
		public int Hours { get; set; }

		[Required(ErrorMessage = "Minimum degree is required")]
		[Range(0, 100, ErrorMessage = "Minimum degree must be between 0 and 100")]
		[Display(Name = "Minimum Degree")]
		public int MinDegree { get; set; }

		[Required(ErrorMessage = "Please select a department")]
		[Display(Name = "Department")]
		public int DepartmentId { get; set; }
		public Department Department { get; set; } = null!;

		public List<Instructor> Instructors { get; set; } = null!;
		public List<CrsResult> CrsResults { get; set; } = null!;
	}
}
