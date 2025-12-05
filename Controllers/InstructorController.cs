using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

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

		public IActionResult Index()
		{
			try
			{
				List<Instructor> instructors = _instructorRepository.GetAll();
				return View(instructors);
			}
			catch (Exception ex)
			{
				return View("Error");
			}

		}

		public IActionResult Details(int id)
		{
			Instructor? instructor = _instructorRepository.GetByIdWithCourseAndDepartment(id);
			if(instructor == null)
				return NotFound();
			return View("Details", instructor);
		}

		[HttpGet]
		public IActionResult Create()
		{
			InstructorWithCoursesAndDepartmentsViewModel viewModel = new InstructorWithCoursesAndDepartmentsViewModel();

			viewModel.Courses = _courseRepository.GetAll();
			viewModel.Departments = _departmentRepository.GetAll();

			return View("Create", viewModel);
		}

		[HttpPost]
		public IActionResult Create(InstructorWithCoursesAndDepartmentsViewModel viewModel)
		{
			viewModel.Courses = _courseRepository.GetAll();
			viewModel.Departments = _departmentRepository.GetAll();

			Instructor newInstructor = new Instructor()
			{
				Name = viewModel.Name,
				Adress = viewModel.Adress,
				ImageURL = viewModel.ImageURL,
				Salary = viewModel.Salary,
				Course = _courseRepository.GetById(viewModel.CourseId),
				Department = _departmentRepository.GetById(viewModel.DepartmentId),
			};

			_instructorRepository.Add(newInstructor);
			_instructorRepository.Save();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var instructor = _instructorRepository.GetById(id);
			if (instructor == null)
				return NotFound();

			try
			{
				_instructorRepository.Delete(instructor);
				_instructorRepository.Save();
				TempData["Success"] = "Instructor deleted successfully.";
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{

				TempData["Error"] = "Failed to delete instructor.";
				return RedirectToAction("Index");
			}
		}



		[HttpGet]
		public IActionResult Search(string name)
		{

			var instructors = _instructorRepository.SearchByNameContains(name);

			return View("ShowAll", instructors);
		}

	}
}
