namespace FirstProject.ViewModel
{
	public class EmpDeptColorTempMsgBrchViewModel
	{
		public string EmpName { get; set; } = null!;
		public string DeptName { get; set; } = null!;
		public List<string> Branches { get; set; } = new List<string>();
		public int Temp { get; set; }
		public string Msg { get; set; } = null!;
		public string Color { get; set; } = null!;
	}
}
