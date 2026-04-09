using AspNetCoreBlogMVC.Data;
using AspNetCoreBlogMVC.Models.Domain;

namespace AspNetCoreBlogMVC.Repositories
{
	public class BlogPostCommentRepository : IBlogPostCommentRepository
	{
		private readonly BlogDbContext blogDbContext;

		public BlogPostCommentRepository(BlogDbContext blogDbContext)
		{
			this.blogDbContext = blogDbContext;
		}
		public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
		{
			await blogDbContext.BlogPostComment.AddAsync(blogPostComment);
			await blogDbContext.SaveChangesAsync();
			return blogPostComment;
		}
	}
}
