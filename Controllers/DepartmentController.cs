using FirstProject.Data;
using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FirstProject.Controllers
{
	public class DepartmentController : Controller
	{
		AppDbContext _context;
		IDepartmentRepository _departmentRepository;

		public DepartmentController(IDepartmentRepository departmentRepository, AppDbContext context)
		{
			_departmentRepository = departmentRepository;
			_context = context;
			
		}

		[Authorize]
		public IActionResult Index()
		{
			List<Department> departmentList = _departmentRepository.GetAll();

			return View("Index", departmentList);

		}

		public IActionResult Add()
		{
			return View("Add");
		}

		[HttpPost]
		public IActionResult SaveAdd(Department department)
		{
			if(department.Name == null || department.ManagerName == null)
				return View("Add", department);

			_departmentRepository.Add(department);
			_departmentRepository.Save();

			return RedirectToAction("Index");
			
		}


		public JsonResult Partial(int id)
		{
			var emp = _context.Employee.Where(x => x.Id == id).ToList();
			return Json(emp);
		}


		public IActionResult Department()
		{
			return View(_departmentRepository.GetAll());
		}
	}
}
