using AspNetCoreBlogMVC.Data;
using AspNetCoreBlogMVC.Models.Domain;
using AspNetCoreBlogMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBlogMVC.Controllers
{
    public class AdminTagsController : Controller
    {
		private readonly BlogDbContext blogDbContext;
		public AdminTagsController(BlogDbContext blogDbContext)
		{
			this.blogDbContext = blogDbContext;
		}

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

			// var name = addTagRequest.Name;
			// var displayName = addTagRequest.DisplayName;

			// mapping AddTagRequest to Tag domain model 
			var tag = new Tag
			{
				Name = addTagRequest.Name,
				DisplayName = addTagRequest.DisplayName
			};

			blogDbContext.Tags.Add(tag);
			blogDbContext.SaveChanges();

			//return View("Add");
			return RedirectToAction("List");
		}

		[HttpGet]
		[ActionName("List")]
		public IActionResult List()
		{
			// use dbContext to read the tags
			var tags = blogDbContext.Tags.ToList();

			return View(tags);
		}
	}
}
