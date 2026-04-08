namespace AspNetCoreBlogMVC.Repositories
{
	public interface IBlogPostLikeRepository
	{
		Task<int> GetTotalLikes(Guid blogPostId);
	}
}
