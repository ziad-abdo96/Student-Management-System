namespace FirstProject.Models.Entities
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int Degree { get; set; }
		public int Hours {  get; set; }
		public int MinDegree { get; set; }

		public Department Department { get; set; } = null!;

		public List<Instructor> Instructors { get; set; } = null!;
		public List<CrsResult> CrsResults { get; set; } = null!;
	}
}
