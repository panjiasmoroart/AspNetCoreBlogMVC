using Microsoft.AspNetCore.Identity;

namespace AspNetCoreBlogMVC.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<IdentityUser>> GetAll();
	}
}
