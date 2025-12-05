using FirstProject.Repositories.Interfaces;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using FirstProject.Filters;
using Microsoft.AspNetCore.Authorization;
namespace FirstProject.Controllers
{
	public class TraineeController : Controller
	{
		ITraineeRepository _trainee;

		public TraineeController(ITraineeRepository trainee)
		{
			_trainee = trainee;
		}

		
		public IActionResult exption()
		{
			throw new NotImplementedException();
		}

		[Authorize]
		public IActionResult Index()
		{
			var trainees = _trainee.GetAll();
			return View(trainees);
		}

		public IActionResult ShowResult(int traineeId, int courseId)
		{
			var result = _trainee.GetTraineeCourseResult(traineeId, courseId);

			if (result == null)
				return NotFound();

			var vm = new TraineeCourseResultViewModel
			{
				TraineeName = result.Trainee.Name,
				CourseName = result.Course.Name,
				Degree = result.Degree,
				Color = result.Degree >= result.Course.MinDegree ? "green" : "red",
				States = result.Degree >= result.Course.MinDegree ? "Pass" : "Fail",
			};

			return View(vm);
		}
		public IActionResult ShowTraineeResult(int id)
		{
			var results = _trainee.GetAllResultsForTrainee(id);

			if (!results.Any())
				return NotFound("No results found for this trainee.");

			var vm = results.Select(r => new TraineeCourseResultViewModel
			{
				CourseName = r.Course.Name,
				Degree = r.Degree
			}).ToList();


			ViewBag.Trainee = results[0].Trainee;

			return View(vm);
		}


	}
}
