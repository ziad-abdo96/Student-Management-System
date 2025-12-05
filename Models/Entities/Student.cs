using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models.Entities
{
	public class Student
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Address { get; set; } = null!;

		public int Age {  get; set; }

		[Display(Name = "Image")]

		public string ImageURL { get; set; } = null!;
		
		public Department Department { get; set; } = null!;

		public List<Instructor> Instructors { get; set; } = null!;
	
		public List<CrsResult> CrsResults { get; set; } = null!;
	}
}
 