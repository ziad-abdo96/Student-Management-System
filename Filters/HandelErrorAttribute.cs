using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstProject.Filters
{
	public class HandelErrorAttribute : Attribute, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			ViewResult view = new ViewResult();
			view.ViewName = "Error";
			context.Result = view;
		}
	}
}
