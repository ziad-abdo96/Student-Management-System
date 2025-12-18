using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProject.Controllers
{
	public class TraineeController : Controller
	{
		private readonly ITraineeRepository _traineeRepository;
		private readonly IDepartmentRepository _departmentRepository;

		public TraineeController(ITraineeRepository traineeRepository, IDepartmentRepository departmentRepository)
		{
			_traineeRepository = traineeRepository;
			_departmentRepository = departmentRepository;
		}

		//################################################################
		public IActionResult Index(string? search)
		{
			search = search?.Trim();

			var trainees = string.IsNullOrWhiteSpace(search)
				? _traineeRepository.GetAllWithDepartments()
				: _traineeRepository.SearchByNameWithDepartments(search);

			ViewBag.CurrentSearch = search;
			return View("Index", trainees);
		}

		/////////////////////////////////////////////////////////////////////////
		[HttpGet]
		public IActionResult Create()
		{
			var viewModel = new TraineeWithDepartListViewModel
			{
				DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name")
			};

			return View(viewModel);
		}

		/////////////////////////////////////////////////////////////////////
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(TraineeWithDepartListViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
				return View(viewModel);
			}

			var trainee = MapToTrainee(viewModel);

			_traineeRepository.Add(trainee);
			_traineeRepository.Save();

			TempData["SuccessMessage"] = "Trainee created successfully!";
			return RedirectToAction("Index");
		}

		/////////////////////////////////////////////////////////////////////
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var trainee = _traineeRepository.GetById(id);

			if (trainee == null)
			{
				TempData["ErrorMessage"] = "Trainee not found.";
				return RedirectToAction("Index");
			}

			var viewModel = new TraineeWithDepartListViewModel
			{
				Id = trainee.Id,
				Name = trainee.Name,
				Address = trainee.Address,
				ImageURL = trainee.ImageURL,
				Grade = trainee.Grade,
				DepartmentId = trainee.DepartmentId,
				DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name")
			};

			return View(viewModel);
		}

		///////////////////////////////////////////////////////////////////// 
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(TraineeWithDepartListViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
				return View(viewModel);
			}

			var trainee = _traineeRepository.GetById(viewModel.Id);

			if (trainee == null)
			{
				TempData["ErrorMessage"] = "Trainee not found.";
				return RedirectToAction("Index");
			}

			trainee.Name = viewModel.Name;
			trainee.Address = viewModel.Address;
			trainee.ImageURL = viewModel.ImageURL;
			trainee.Grade = viewModel.Grade;
			trainee.DepartmentId = viewModel.DepartmentId;

			_traineeRepository.Update(trainee);
			_traineeRepository.Save();

			TempData["SuccessMessage"] = "Trainee updated successfully!";
			return RedirectToAction("Index");
		}

		/////////////////////////////////////////////////////////////////////
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var trainee = _traineeRepository.GetById(id);

			if (trainee == null)
			{
				TempData["ErrorMessage"] = "Trainee not found.";
				return RedirectToAction("Index");
			}

			return View(trainee);
		}
		
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var trainee = _traineeRepository.GetById(id);

			if (trainee == null)
			{
				TempData["ErrorMessage"] = "Trainee not found.";
				return RedirectToAction("Index");
			}

			string traineeName = trainee.Name;

			trainee.IsDeleted = true;
			trainee.DeletedAt = DateTime.UtcNow;

			_traineeRepository.Update(trainee);
			_traineeRepository.Save();

			TempData["SuccessMessage"] = $"Trainee '{traineeName}' deleted successfully!";
			return RedirectToAction("Index");
		}

		////////////////////////////////////////////////////////////////////
		private Trainee MapToTrainee(TraineeWithDepartListViewModel viewModel)
		{
			return new Trainee
			{
				Name = viewModel.Name,
				Address = viewModel.Address,
				ImageURL = viewModel.ImageURL,
				Grade = viewModel.Grade,
				DepartmentId = viewModel.DepartmentId
			};
		}
	}
}