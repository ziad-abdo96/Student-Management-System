namespace FirstProject.ViewModel
{
	public class TraineeCourseResultViewModel
	{
		public string TraineeName { get; set; } = null!;
		public string CourseName { get; set; } = null!;
		public int Degree { get; set; }
		public string Color { get; set; } = null!;
		public bool IsPassed => Color == "success";
	}
}
