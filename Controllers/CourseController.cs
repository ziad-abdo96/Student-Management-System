using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

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
			List<Course> courses;

			if (string.IsNullOrWhiteSpace(search))
			{
				courses = _course.GetAllWithDepartments();
			}
			else
			{
				courses = _course.SearchByNameWithDepartments(search);
			}


			ViewBag.CurrentSearch = search;

			return View(courses);
		}


		public IActionResult ShowCourseResult(int id)
		{
			var results = _course.GetResultsByCourseId(id);

			if (results == null || !results.Any())
			{
				return NotFound();
			}

			var vm = results.Select(result => new TraineeCourseResultViewModel
			{
				TraineeName = result.Trainee?.Name ?? "Unknown",
				Degree = result.Degree,
				Color = result.Degree >= result.Course.MinDegree ? "success" : "danger"
			}).ToList();

			ViewBag.CourseName = results.FirstOrDefault()?.Course?.Name;
			ViewBag.CourseId = id;

			return View(vm);

		}


		[HttpGet]
		public IActionResult Create()
		{
			var viewModel = new CourseWithDepartmentViewModel
			{
				DepartmentList = new SelectList(_department.GetAll(), "Id", "Name")
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CourseWithDepartmentViewModel viewModel)
		{
			if(!ModelState.IsValid)
			{
				viewModel.DepartmentList = new SelectList(_department.GetAll(), "Id", "Name");
				return View(viewModel);
			}

			var course = new Course
			{
				Name = viewModel.Name,
				Degree = viewModel.Degree,
				Hours = viewModel.Hours,
				MinDegree = viewModel.MinDegree,
				Department = _department.GetById(viewModel.DepartmentId),
			};

			_course.Add(course);
			_course.Save();
			TempData["SuccessMessage"] = "Course created successfully!";
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var course = _course.GetById(id);
			if(course == null)
			{
				TempData["ErrorMessage"] = "Course not found.";
				return RedirectToAction("Index");
			}

			var viewModel = new CourseWithDepartmentViewModel
			{
				Id = course.Id,
				Name = course.Name,
				Degree = course.Degree,
				Hours = course.Hours,
				MinDegree = course.MinDegree,
				DepartmentId = course.DepartmentId,
				DepartmentList = new SelectList(_department.GetAll(), "Id", "Name", course.DepartmentId)
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(CourseWithDepartmentViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.DepartmentList = new SelectList(_department.GetAll(), "Id", "Name", viewModel.DepartmentId);
				return View(viewModel);
			}
			var course = _course.GetById(viewModel.Id);
			if(course == null)
			{
				TempData["ErrorMessage"] = "Course not found.";
				return RedirectToAction("Index");
			}
			course.Name = viewModel.Name;
			course.Degree = viewModel.Degree;
			course.Hours = viewModel.Hours;
			course.MinDegree = viewModel.MinDegree;
			course.DepartmentId = viewModel.DepartmentId;
			_course.Update(course);
			_course.Save();
			TempData["SuccessMessage"] = "Course updated successfully!";
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var course = _course.GetById(id);
			if (course == null)
			{
				TempData["ErrorMessage"] = "Course not found.";
				return RedirectToAction("Index");
			}
			_course.Delete(course);
			_course.Save();
			TempData["SuccessMessage"] = $"Course '{course.Name}' deleted successfully!";
			return RedirectToAction("Index");
		}
	}
}
