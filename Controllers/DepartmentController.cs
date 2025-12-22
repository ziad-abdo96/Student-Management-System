using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FirstProject.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentController(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}
		public IActionResult Index(string? search)
		{
			search = search?.Trim();
			var departments = string.IsNullOrWhiteSpace(search)
				? _departmentRepository.GetAll()
				: _departmentRepository.SearchByName(search);
			ViewBag.CurrentSearch = search;
			return View(departments);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Department department)
		{
			if (!ModelState.IsValid)
			{
				return View(department);
			}

			try
			{
				_departmentRepository.Add(department);
				_departmentRepository.Save();

				TempData["SuccessMessage"] = $"Department '{department.Name}' created successfully!";
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "An error occurred while creating the department.");
				return View(department);
			}
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var department = _departmentRepository.GetById(id);

			if (department == null)
			{
				TempData["ErrorMessage"] = "Department not found.";
				return RedirectToAction("Index");
			}

			return View(department);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, Department department)
		{
			if (id != department.Id)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(department);
			}

			try
			{
				_departmentRepository.Update(department);
				_departmentRepository.Save();

				TempData["SuccessMessage"] = $"Department '{department.Name}' updated successfully!";
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "An error occurred while updating the department.");
				return View(department);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var department = _departmentRepository.GetById(id);
			if (department == null)
			{
				TempData["ErrorMessage"] = "Department not found.";
				return RedirectToAction("Index");
			}

			return View(department);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var department = _departmentRepository.GetById(id);

			if (department == null)
			{
				TempData["ErrorMessage"] = "Department not found.";
				return RedirectToAction(nameof(Index));
			}

			try
			{
				department.IsDeleted = true;
				department.DeletedAt = DateTime.UtcNow;

				_departmentRepository.Update(department);
				_departmentRepository.Save();

				TempData["SuccessMessage"] = $"Department '{department.Name}' deleted successfully!";
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "An error occurred while deleting the department.";
				return RedirectToAction(nameof(Index));
			}
		}
	}
}