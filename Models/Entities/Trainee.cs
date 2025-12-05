namespace FirstProject.Models.Entities
{
	public class Trainee
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string ImageURL { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string Grade { get; set; } = null!;

		public List<CrsResult> CrsResults { get; set; } = null!;

		public Department Department { get; set; } = null!;
	}
}
