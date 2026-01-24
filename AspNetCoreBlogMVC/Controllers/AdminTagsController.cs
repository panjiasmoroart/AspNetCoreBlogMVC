using AspNetCoreBlogMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBlogMVC.Controllers
{
    public class AdminTagsController : Controller
    {
		[HttpGet]
		public IActionResult Add()
        {
            return View();
        }

		
		[HttpPost]
		[ActionName("Add")]
		public IActionResult SubmitTag(AddTagRequest addTagRequest)
		{
			// form submission and data binding ASP.NET 
			// var name = Request.Form["name"];
			// var displayName = Request.Form["displayName"];

			var name = addTagRequest.Name;
			var displayName = addTagRequest.DisplayName;

			return View("Add");
		}
	}
}
