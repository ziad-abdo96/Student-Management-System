using FirstProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstProject.Controllers
{
	[Authorize(Roles="admin")]
	public class RoleController : Controller
	{

		RoleManager<IdentityRole> _roleManager;

		public RoleController(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}

		// GET: RoleController
		public ActionResult Index()
		{
			return View();
		}

		// GET: RoleController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			return View();
		}

		// POST: RoleController/Create
		[HttpPost]
		public async Task<ActionResult> Create(RoleViewModel roleViewModel)
		{
			if(ModelState.IsValid)
			{
				IdentityRole role = new IdentityRole();
				role.Name = roleViewModel.RoleName;
				IdentityResult result = await _roleManager.CreateAsync(role);
			
				if(result.Succeeded)
				{
					ViewBag.succeeded = true;
					return View("Create");
				}

				foreach(var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View("Create", roleViewModel);
			}
			return View(roleViewModel);
		}

		// GET: RoleController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: RoleController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: RoleController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: RoleController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
