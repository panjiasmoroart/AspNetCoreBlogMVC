using AspNetCoreBlogMVC.Models.Domain;

namespace AspNetCoreBlogMVC.Repositories
{
	public interface IBlogPostCommentRepository
	{
		Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
	}
}
