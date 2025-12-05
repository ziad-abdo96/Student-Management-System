using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FirstProject.Controllers
{
	public class CourseController : Controller
	{
		ICourseRepository _course;
		IDepartmentRepository _department;
		public CourseController(ICourseRepository course, IDepartmentRepository department)
		{
			_course = course;
			_department = department;
		}

		public IActionResult Index(string? search)
		{
			List<Course> courses = _course.GetAll();

			if(!search.IsNullOrEmpty())
			{
				courses = courses.Where(c => c.Name.Contains(search)).ToList();
			}
			return View(courses);
		}


		public IActionResult ShowCourseResult(int id)
		{
			var results = _course.GetResultsByCourseId(id);

			List<TraineeCourseResultViewModel> vm = new List<TraineeCourseResultViewModel>();



			foreach (var result in results)
			{
				vm.Add(new TraineeCourseResultViewModel
				{
					TraineeName = result.Trainee.Name,
					Degree = result.Degree,
					Color = result.Degree >= result.Course.MinDegree ? "green" : "red"
				});
			}

			return View(vm);

		}


		[HttpGet]
		public IActionResult Create()
		{
			List<Department> departments = _department.GetAll();
			CourseWithDepartmentViewModel viewModel = new CourseWithDepartmentViewModel();
			viewModel.Departments = departments;

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Create(CourseWithDepartmentViewModel viewModel)
		{
			if(viewModel.Name ==  null || viewModel.Degree <= 0 || viewModel.Hours <= 0 || viewModel.MinDegree <= 0 || viewModel.DepartmentId <= 0)
			{
				List<Department> departments = _department.GetAll();
				viewModel.Departments = departments;
				return View(viewModel);
			}

			Course course = new Course
			{
				Name = viewModel.Name,
				Degree = viewModel.Degree,
				Hours = viewModel.Hours,
				MinDegree = viewModel.MinDegree,
				Department = _department.GetById(viewModel.DepartmentId),
			};

			_course.Add(course);
			_course.Save();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var course = _course.GetById(id);

			if (course == null)
				return NotFound();

			_course.Delete(course);
			_course.Save();

			return RedirectToAction("Index");
		}



	}
}
