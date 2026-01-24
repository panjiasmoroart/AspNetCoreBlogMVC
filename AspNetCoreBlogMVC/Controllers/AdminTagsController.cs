using AspNetCoreBlogMVC.Data;
using AspNetCoreBlogMVC.Models.Domain;
using AspNetCoreBlogMVC.Models.ViewModels;
using Azure;
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

		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			// 1st method 
			// var tag = blogDbContext.Tags.Find(id); 

			// 2nd method 
			var tag = blogDbContext.Tags.FirstOrDefault(x => x.Id == id);

			if (tag != null)
			{
				var editTagRequest = new EditTagRequest
				{
					Id = tag.Id,
					Name = tag.Name,
					DisplayName = tag.DisplayName
				};

				return View(editTagRequest);
			}

			return View(null);
		}

		[HttpPost]
		public IActionResult Edit(EditTagRequest editTagRequest)
		{
			var tag = new Tag
			{
				Id = editTagRequest.Id,
				Name = editTagRequest.Name,
				DisplayName = editTagRequest.DisplayName
			};

			var existingTag = blogDbContext.Tags.Find(tag.Id);

			if (existingTag != null)
			{
				existingTag.Name = tag.Name;
				existingTag.DisplayName = tag.DisplayName;

				// save changes 
				blogDbContext.SaveChanges();

				// show success notification 
				return RedirectToAction("Edit", new { id = editTagRequest.Id });
			}

			// show failure notification
			return RedirectToAction("Edit", new { id = editTagRequest.Id });
		}

		[HttpPost]
		public IActionResult Delete(EditTagRequest editTagRequest)
		{
			var tag = blogDbContext.Tags.Find(editTagRequest.Id);

			if (tag != null)
			{
				blogDbContext.Tags.Remove(tag);
				blogDbContext.SaveChanges();
		
				// show a success notification 
				return RedirectToAction("List");
			}
			
			// show an error notification
			return RedirectToAction("Edit", new { id = editTagRequest.Id });
		}


	}
}
