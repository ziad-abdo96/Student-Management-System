using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models.Entities
{
    public class Instructor
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Instructor name is required")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
		[Display(Name = "Instructor Name")]
		public string Name { get; set; } = string.Empty;

		[StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
		[Url(ErrorMessage = "Please enter a valid URL")]
		[Display(Name = "Profile Image URL")]
		public string? ImageURL { get; set; }

		[Required(ErrorMessage = "Salary is required")]
		[Column(TypeName = "decimal(18,2)")]
		[Range(0.01, 999999999, ErrorMessage = "Salary must be greater than 0")]
		[Display(Name = "Salary")]
		[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
		public decimal Salary { get; set; }

		[Required(ErrorMessage = "Address is required")]
		[StringLength(200, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 200 characters")]
		[Display(Name = "Address")]
		public string? Address { get; set; }

		[Required(ErrorMessage = "Please select a department")]
		[Display(Name = "Department")]
		public int DepartmentId { get; set; }

		[Required(ErrorMessage = "Please select a course")]
		[Display(Name = "Course")]
		public int CourseId { get; set; }

		public Department Department { get; set; } = null!;
        public Course Course { get; set; } = null!;
	}
}