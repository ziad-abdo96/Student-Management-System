using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models.Entities
{
	public class Instructor
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string ImageURL { get; set; } = null!;

		public decimal Salary { get; set; }

		public string Adress { get; set; } = null!;

		public Department Department { get; set; } = null!;

		public Course Course { get; set; } = null!;
	}
}
