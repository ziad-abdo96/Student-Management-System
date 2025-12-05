using FirstProject.Models.Entities;
using FirstProject.Repositories.Implementations;
using FirstProject.Repositories.Interfaces;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
	public class EmployeeController : Controller
	{
		
		IEmployeeRepository employeeRepository;
		IDepartmentRepository departmentRepository;
		public EmployeeController(IEmployeeRepository _employeeRepository, IDepartmentRepository _departmentRepository)
		{
			employeeRepository = _employeeRepository;
			departmentRepository = _departmentRepository;
		}
		/////////////////////////////////////////////////////////////////////
		public IActionResult Index()
		{
			List<Employee> employees = employeeRepository.GetAll();

			return View("Index", employees);
		}


		[HttpGet]
		public IActionResult Create()
		{
			EmpWithDepartListViewModel viewModel = new EmpWithDepartListViewModel();
			List<Department> departments = departmentRepository.GetAll();

			viewModel.Departments = departments;

			return View(viewModel);
		}

		/////////////////////////////////////////////////////////////////////
		[HttpPost]
		public IActionResult Create(EmpWithDepartListViewModel viewModel)
		{
			if (viewModel.Name == null || viewModel.JobTitle == null || viewModel.DepartmentID == 0 || viewModel.ImageURL == null)
			{
				List<Department> departments = departmentRepository.GetAll();
				viewModel.Departments = departments;
				return View(viewModel);
			}

			Employee employee = new Employee
			{
				Name = viewModel.Name,
				Salary = viewModel.Salary,
				Address = viewModel.Address,
				JobTitle = viewModel.JobTitle,
				ImageURL = viewModel.ImageURL,
				DepartmentID = viewModel.DepartmentID,
			};

			employeeRepository.Add(employee);
			employeeRepository.Save();

			return RedirectToAction("Index");
		}

		/////////////////////////////////////////////////////////////////////
		public IActionResult Edit(int id)
		{
			Employee? employee = employeeRepository.GetById(id);
			List<Department> departments = departmentRepository.GetAll();
			if (employee == null)
				return NotFound();

			EmpWithDepartListViewModel viewModel = new EmpWithDepartListViewModel();

			viewModel.Id = employee.Id;
			viewModel.Name = employee.Name;
			viewModel.Salary = employee.Salary;
			viewModel.Address = employee.Address;
			viewModel.ImageURL = employee.ImageURL;
			viewModel.JobTitle = employee.JobTitle;
			viewModel.DepartmentID = employee.DepartmentID;	
			viewModel.Departments = departments;
			

			return View("Edit", viewModel);
		}

		/////////////////////////////////////////////////////////////////////
		public IActionResult SaveEdit(EmpWithDepartListViewModel viewModel)
		{
			if (viewModel.Name == null || viewModel.Salary == 0 || viewModel.JobTitle == null || viewModel.ImageURL == null)
			{
				List<Department> departments = departmentRepository.GetAll();
				viewModel.Departments = departments;
				return View("Edit", viewModel);
			}

			Employee? employeeDB = employeeRepository.GetById(viewModel.Id);

			if (employeeDB == null)
				return NotFound();

			employeeDB.Name = viewModel.Name;
			employeeDB.Salary = viewModel.Salary;
			employeeDB.Address = viewModel.Address;
			employeeDB.JobTitle = viewModel.JobTitle;
			employeeDB.ImageURL = viewModel.ImageURL;
			employeeDB.DepartmentID = viewModel.DepartmentID;

			employeeRepository.Save();

			return RedirectToAction("Index");
		}

		/////////////////////////////////////////////////////////////////////
		public IActionResult Details(int id) 
		{
			string msg = "Hello From Action";
			int temp = 50;
			List<string> branches = new List<string>()
			{
				"Assuit",
				"Alex",
				"Cario",
			};

			ViewData["Msg"] = msg;
			ViewData["Temp"] = temp;
			ViewData["Brch"] = branches;
			
			Employee? EmpModel = employeeRepository.GetById(id);

			return View("Details", EmpModel);
		}


		public IActionResult EmployeePartial(int id)
		{
			string msg = "Hello From Action";
			int temp = 50;
			List<string> branches = new List<string>()
			{
				"Assuit",
				"Alex",
				"Cario",
			};

			ViewData["Msg"] = msg;
			ViewData["Temp"] = temp;
			ViewData["Brch"] = branches;

			return PartialView("_EmployeeCardPartail", employeeRepository.GetById(id));
		}


		public IActionResult Delete(int id)
		{
			return View(employeeRepository.GetById(id));
		}


		/////////////////////////////////////////////////////////////////////
		public IActionResult DetailsVM(int id)
		{
			Employee? EmpModel = employeeRepository.GetByIdWithDepartment(id);

			List<string> branches = new List<string>()
			{
				"Assuit",
				"Alex",
				"Cario",
			};

			//declare viewMode
			EmpDeptColorTempMsgBrchViewModel EmpVM =
				new EmpDeptColorTempMsgBrchViewModel();
			//Mapping to model
			EmpVM.EmpName = EmpModel.Name;
			EmpVM.DeptName = EmpModel.Department.Name;
			EmpVM.Color = "Red";
			EmpVM.Temp = 12;
			EmpVM.Msg = "Hello From VM";
			EmpVM.Branches = branches;
			return View("DetailsVM", EmpVM);
		}


	}
}
