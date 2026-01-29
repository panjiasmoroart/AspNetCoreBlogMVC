using AspNetCoreBlogMVC.Data;
using AspNetCoreBlogMVC.Models.Domain;
using AspNetCoreBlogMVC.Models.ViewModels;
using AspNetCoreBlogMVC.Repositories;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBlogMVC.Controllers
{
	public class AdminTagsController : Controller
	{
		//private readonly BlogDbContext blogDbContext;
		//public AdminTagsController(BlogDbContext blogDbContext)
		//{
		//	this.blogDbContext = blogDbContext;
		//}

		private readonly ITagRepository tagRepository;
		public AdminTagsController(ITagRepository tagRepository)
		{
			this.tagRepository = tagRepository;
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}


		[HttpPost]
		[ActionName("Add")]
		//public IActionResult SubmitTag(AddTagRequest addTagRequest)
		//{
		//	// form submission and data binding ASP.NET 
		//	// var name = Request.Form["name"];
		//	// var displayName = Request.Form["displayName"];

		//	// var name = addTagRequest.Name;
		//	// var displayName = addTagRequest.DisplayName;

		//	// mapping AddTagRequest to Tag domain model 
		//	var tag = new Tag
		//	{
		//		Name = addTagRequest.Name,
		//		DisplayName = addTagRequest.DisplayName
		//	};

		//	blogDbContext.Tags.Add(tag);
		//	blogDbContext.SaveChanges();

		//	//return View("Add");
		//	return RedirectToAction("List");
		//}
		public async Task<IActionResult> Add(AddTagRequest addTagRequest)
		{
			// Mapping AddTagRequest to Tag domain model
			var tag = new Tag
			{
				Name = addTagRequest.Name,
				DisplayName = addTagRequest.DisplayName
			};

			//await blogDbContext.Tags.AddAsync(tag);
			//await blogDbContext.SaveChangesAsync();

			//repository pattern
			await tagRepository.AddAsync(tag);

			return RedirectToAction("List");
		}

		[HttpGet]
		[ActionName("List")]
		//public IActionResult List()
		//{
		//	// use dbContext to read the tags
		//	var tags = blogDbContext.Tags.ToList();

		//	return View(tags);
		//}
		public async Task<IActionResult> List()
		{
			//var tags = await blogDbContext.Tags.ToListAsync();
			var tags = await tagRepository.GetAllAsync();

			return View(tags);
		}

		[HttpGet]
		//public IActionResult Edit(Guid id)
		//{
		//	// 1st method 
		//	// var tag = blogDbContext.Tags.Find(id); 

		//	// 2nd method 
		//	var tag = blogDbContext.Tags.FirstOrDefault(x => x.Id == id);

		//	if (tag != null)
		//	{
		//		var editTagRequest = new EditTagRequest
		//		{
		//			Id = tag.Id,
		//			Name = tag.Name,
		//			DisplayName = tag.DisplayName
		//		};

		//		return View(editTagRequest);
		//	}

		//	return View(null);
		//}
		public async Task<IActionResult> Edit(Guid id)
		{
			//var tag = await blogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);

			var tag = await tagRepository.GetAsync(id);

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
		//public IActionResult Edit(EditTagRequest editTagRequest)
		//{
		//	var tag = new Tag
		//	{
		//		Id = editTagRequest.Id,
		//		Name = editTagRequest.Name,
		//		DisplayName = editTagRequest.DisplayName
		//	};

		//	var existingTag = blogDbContext.Tags.Find(tag.Id);

		//	if (existingTag != null)
		//	{
		//		existingTag.Name = tag.Name;
		//		existingTag.DisplayName = tag.DisplayName;

		//		// save changes 
		//		blogDbContext.SaveChanges();

		//		// show success notification 
		//		return RedirectToAction("Edit", new { id = editTagRequest.Id });
		//	}

		//	// show failure notification
		//	return RedirectToAction("Edit", new { id = editTagRequest.Id });
		//}
		public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
		{
			var tag = new Tag
			{
				Id = editTagRequest.Id,
				Name = editTagRequest.Name,
				DisplayName = editTagRequest.DisplayName
			};

			//var existingTag = await blogDbContext.Tags.FindAsync(tag.Id);

			//if (existingTag != null)
			//{
			//	existingTag.Name = tag.Name;
			//	existingTag.DisplayName = tag.DisplayName;

			//	// save changes 
			//	await blogDbContext.SaveChangesAsync();

			//	// show success notification 
			//	return RedirectToAction("Edit", new { id = editTagRequest.Id });
			//}

			var updatedTag = await tagRepository.UpdateAsync(tag);

			if (updatedTag != null)
			{
				// Show success notification
			}
			else
			{
				// Show error notification
			}

			// show failure notification
			return RedirectToAction("Edit", new { id = editTagRequest.Id });
		}

		[HttpPost]
		//public IActionResult Delete(EditTagRequest editTagRequest)
		//{
		//	var tag = blogDbContext.Tags.Find(editTagRequest.Id);

		//	if (tag != null)
		//	{
		//		blogDbContext.Tags.Remove(tag);
		//		blogDbContext.SaveChanges();

		//		// show a success notification 
		//		return RedirectToAction("List");
		//	}

		//	// show an error notification
		//	return RedirectToAction("Edit", new { id = editTagRequest.Id });
		//}
		public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
		{
			//var tag = await blogDbContext.Tags.FindAsync(editTagRequest.Id);

			//if (tag != null)
			//{
			//	blogDbContext.Tags.Remove(tag);
			//	await blogDbContext.SaveChangesAsync();

			//	// show a success notification 
			//	return RedirectToAction("List");
			//}

			var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

			if (deletedTag != null)
			{
				// show a success notification 
				return RedirectToAction("List");
			}

			// show an error notification
			return RedirectToAction("Edit", new { id = editTagRequest.Id });
		}


	}
}
