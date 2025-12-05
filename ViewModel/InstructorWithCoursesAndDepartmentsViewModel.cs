using FirstProject.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace FirstProject.ViewModel
{
	public class InstructorWithCoursesAndDepartmentsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string ImageURL { get; set; } = null!;

		public decimal Salary { get; set; }

		public string Adress { get; set; } = null!;

		public int DepartmentId { get; set; } 

		public int CourseId { get; set; }

		public List<Department> Departments { get; set; } = null!;

		public List<Course> Courses { get; set; } = null!;

	}
}
