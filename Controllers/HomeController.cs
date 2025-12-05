using System.Diagnostics;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {

        //MEthod Public
        //Cant be static
        //cant be overload
        

        //Action Return type
        //String -> ContentREsult   
        //View -> ViewREsult
        //Json -> JsonReslut
        //File -> fileREsult
        //notfound -> notfoundResult
        //unauthor -> unautorResult

        public ContentResult ShowMsg()
        {
            //declare
            ContentResult result = new ContentResult();
            //initial
            result.Content = "view1";
            //return
            return result;
        }

        public ViewResult ShowView()
        {
            //declare
            ViewResult result = new ViewResult();
            //initial
            result.ViewName = "view1";

            //return 
            return result;
        }


        public ActionResult ShowMix(int id)
        {
            if (id % 2 == 0)
            {
                //ViewResult result1 = new ViewResult();
                //result1.ViewName = "ViEw1";
                //return result1;
                return View("vieW1");
            }

			ContentResult result = new ContentResult();
			result.Content = "ali";
			return result;

		}

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
