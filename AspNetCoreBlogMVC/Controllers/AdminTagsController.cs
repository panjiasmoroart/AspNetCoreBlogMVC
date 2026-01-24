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
    }
}
