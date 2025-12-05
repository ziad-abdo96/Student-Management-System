using FirstProject.Models.Entities;

namespace FirstProject.ViewModel
{
	public class CourseWithDepartmentViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int Degree { get; set; }
		public int Hours { get; set; }
		public int MinDegree { get; set; }

		public int DepartmentId { get; set; }

		public Department Department { get; set; } = null!;


		public List<Department> Departments { get; set; } = null!;
	}
}
