using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProject.Controllers
{
	public class EmployeeController : Controller
	{
		
		IEmployeeRepository _employeeRepository;
		IDepartmentRepository _departmentRepository;
		public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
		{
			_employeeRepository = employeeRepository;
			_departmentRepository = departmentRepository;
		}

		//################################################################
		public IActionResult Index(string? search)
		{
			search = search?.Trim();

			var employees = string.IsNullOrWhiteSpace(search)
				? _employeeRepository.GetAllWithDepartments() 
				: _employeeRepository.SearchByNameWithDepartments(search);

			ViewBag.CurrentSearch = search;
			return View("Index", employees);
		}

		/////////////////////////////////////////////////////////////////////////
		[HttpGet]
		public IActionResult Create()
		{
			var viewModel = new EmpWithDepartListViewModel
			{
				DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name"),
			};

			return View(viewModel);
		}

		/////////////////////////////////////////////////////////////////////
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(EmpWithDepartListViewModel viewModel)
		{
			if(!ModelState.IsValid)
			{
				viewModel.DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
				return View(viewModel);
			}

			Employee employee = MapToEmployee(viewModel);

			_employeeRepository.Add(employee);
			_employeeRepository.Save();

			TempData["SuccessMessage"] = "Employee created successfully.";
			return RedirectToAction("Index");
		}

		/////////////////////////////////////////////////////////////////////
		[HttpGet]
		public IActionResult Edit(int id)
		{
			Employee? employee = _employeeRepository.GetById(id);
			if (employee == null)
			{
				TempData["ErrorMessage"] = "Employee not found.";
				return RedirectToAction("Index");
			}

			var viewModel = new EmpWithDepartListViewModel
			{
				Id = employee.Id,
				Name = employee.Name,
				Salary = employee.Salary,
				Address = employee.Address,
				ImageURL = employee.ImageURL,
				JobTitle = employee.JobTitle,
				DepartmentId = employee.DepartmentId,
				DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name"),
			};



			return View(viewModel);
		}

		///////////////////////////////////////////////////////////////////// 
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(EmpWithDepartListViewModel viewModel)
		{
			if(!ModelState.IsValid)
			{
				viewModel.DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
				return View(viewModel);
			}

			var employee = _employeeRepository.GetById(viewModel.Id);

			if (employee == null)
			{
				TempData["ErrorMessage"] = "Employee not found.";
				return RedirectToAction("Index");

			}
			employee.Name = viewModel.Name;
			employee.Salary = viewModel.Salary;
			employee.Address = viewModel.Address;
			employee.JobTitle = viewModel.JobTitle;
			employee.ImageURL = viewModel.ImageURL;
			employee.DepartmentId = viewModel.DepartmentId;

			_employeeRepository.Update(employee);
			_employeeRepository.Save();

			TempData["SuccessMessage"] = "Employee updated successfully!";
			return RedirectToAction("Index");
		}

		/////////////////////////////////////////////////////////////////////

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			var employee = _employeeRepository.GetById(id);

			if (employee == null)
			{
				TempData["ErrorMessage"] = "Employee not found.";
				return RedirectToAction("Index");
			}

			_employeeRepository.Delete(employee);
			_employeeRepository.Save();

			TempData["SuccessMessage"] = $"Employee {employee.Name} deleted successfully!";

			return RedirectToAction("Index");
		}


		////////////////////////////////////////////////////////////////////
		private Employee MapToEmployee(EmpWithDepartListViewModel viewModel)
		{
			return new Employee
			{
				Name = viewModel.Name,
				Salary = viewModel.Salary,
				Address = viewModel.Address,
				JobTitle = viewModel.JobTitle,
				ImageURL = viewModel.ImageURL,
				DepartmentId = viewModel.DepartmentId,
			};
		}
	}
}
