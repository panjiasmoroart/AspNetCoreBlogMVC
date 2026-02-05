using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBlogMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
		
		[HttpGet]
        public IActionResult Index()
        {
			//https://localhost:7194/api/images
			return Ok("This is the GET Images API call");
		}
	}
}
