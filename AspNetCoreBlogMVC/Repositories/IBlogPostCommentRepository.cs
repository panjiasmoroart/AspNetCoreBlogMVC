using AspNetCoreBlogMVC.Models.Domain;

namespace AspNetCoreBlogMVC.Repositories
{
	public interface IBlogPostCommentRepository
	{
		Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);

		// Daftar Koleksi: IEnumerable<BlogPostComment> berarti metode GetCommentsByBlogIdAsync akan mengembalikan banyak komentar, bukan hanya satu
		Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
	}
}
