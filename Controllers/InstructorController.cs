using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProject.Controllers
{
	public class InstructorController : Controller
	{
		IInstructorRepository _instructorRepository;
		ICourseRepository _courseRepository;
		IDepartmentRepository _departmentRepository;

		public InstructorController(IInstructorRepository instructor, ICourseRepository course, IDepartmentRepository department)
		{
			_instructorRepository = instructor;
			_courseRepository = course;
			_departmentRepository = department;
		}

		public IActionResult Index(string? search)
		{
			search = search?.Trim();
			var instructors = string.IsNullOrWhiteSpace(search) ?
				_instructorRepository.GetAllWithCourseAndDepartment() :
				_instructorRepository.SearchByNameContains(search);

			ViewBag.CurrentSearch = search;
			return View(instructors);
		}


		[HttpGet]
		public IActionResult Create()
		{

			var viewModel = new InstructorWithCoursesAndDepartmentsViewModel()
			{
				DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name")	,
			};

			return View(viewModel);
		}


		public IActionResult GetCoursesByDepartment(int departmentId)
		{
			var courseList = new SelectList(_courseRepository.GetCoursesByDepartmentId(departmentId), "Id", "Name");
			return Json(courseList);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(InstructorWithCoursesAndDepartmentsViewModel viewModel)
		{
		
			if (!ModelState.IsValid)
			{
				viewModel.DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
				return View(viewModel);
			}
			
			var newInstructor = new Instructor()
			{
				Name = viewModel.Name,
				Address = viewModel.Address,
				ImageURL = viewModel.ImageURL,
				Salary = viewModel.Salary,
				CourseId = viewModel.CourseId,
				DepartmentId = viewModel.DepartmentId
			};

			_instructorRepository.Add(newInstructor);
			_instructorRepository.Save();

			TempData["SuccessMessage"] = "Instructor created successfully!";
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var instructor = _instructorRepository.GetById(id);
			if (instructor == null)
			{
				TempData["ErrorMessage"] = "Instructor not found.";
				return RedirectToAction("Index");

			}

			try
			{
				_instructorRepository.Delete(instructor);
				_instructorRepository.Save();
				TempData["SuccessMessage"] = "Instructor deleted successfully.";
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{

				TempData["ErrorMessage"] = "Failed to delete instructor.";
				return RedirectToAction("Index");
			}
		}
	}
}
