using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBlogMVC.Controllers
{
    public class BlogPostLikeRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
