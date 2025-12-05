//using FirstProject.Data;
//using FirstProject.Models.Entities;
//using FirstProject.ViewModel;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;

//namespace FirstProject.Controllers
//{
//	public class StudentController : Controller
//	{
//		AppDbContext context = new AppDbContext();
//		public IActionResult Index(string? search)
//		{
//			List<Student> students = context.Student.Include(x => x.Department).ToList();	

//			if(!search.IsNullOrEmpty())
//			{
//				students = students.Where(c => c.Name.Contains(search)).ToList();
//			}
//			return View(students);
//		}

//		[HttpGet]

//		public IActionResult Create()
//		{
//			List<Department> departments = context.Department.ToList();
//			CourseWithDepartmentViewModel viewModel = new CourseWithDepartmentViewModel();
//			viewModel.Departments = departments;

//			return View(viewModel);
//		}

//		[HttpPost]
//		public IActionResult Create(CourseWithDepartmentViewModel viewModel)
//		{
//			if(viewModel.Name ==  null || viewModel.Degree <= 0 || viewModel.Hours <= 0 || viewModel.MinDegree <= 0 || viewModel.DepartmentId <= 0)
//			{
//				List<Department> departments = context.Department.ToList();
//				viewModel.Departments = departments;
//				return View(viewModel);
//			}

//			Course course = new Course
//			{
//				Name = viewModel.Name,
//				Degree = viewModel.Degree,
//				Hours = viewModel.Hours,
//				MinDegree = viewModel.MinDegree,
//				Department = context.Department.FirstOrDefault(d => d.Id == viewModel.DepartmentId),
//			};

//			context.Course.Add(course);
//			context.SaveChanges();

//			return RedirectToAction("Index");
//		}

//		[HttpPost]
//		public IActionResult Delete(int id)
//		{
//			var course = context.Course.FirstOrDefault(c => c.Id == id);

//			if (course == null)
//				return NotFound();

//			context.Course.Remove(course);
//			context.SaveChanges();

//			return RedirectToAction("Index");
//		}



//	}
//}
