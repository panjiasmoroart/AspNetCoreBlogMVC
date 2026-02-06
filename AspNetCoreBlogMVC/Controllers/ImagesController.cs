using System.Net;
using AspNetCoreBlogMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBlogMVC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly IImageRespository imageRespository;

		public ImagesController(IImageRespository imageRespository)
		{
			this.imageRespository = imageRespository;
		}

		//[HttpGet]
		//      public IActionResult Index()
		//      {
		//	//https://localhost:7194/api/images
		//	return Ok("This is the GET Images API call");
		//}

		[HttpPost]
		public async Task<IActionResult> UploadAsync(IFormFile file)
		{
			// call a repository
			var imageURL = await imageRespository.UploadAsync(file);
			if (imageURL == null)
			{
				return Problem("Sometihng went wrong!", null, (int)HttpStatusCode.InternalServerError);
			}

			return new JsonResult(new { link = imageURL });
		}
	}
}
