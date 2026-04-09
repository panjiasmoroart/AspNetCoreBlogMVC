using AspNetCoreBlogMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBlogMVC.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly AuthDbContext authDbContext;
		public UserRepository(AuthDbContext authDbContext)
		{
			this.authDbContext = authDbContext;
		}

		public async Task<IEnumerable<IdentityUser>> GetAll()
		{
			var users = await authDbContext.Users.ToListAsync();

			var superAdminUser = await authDbContext.Users
				.FirstOrDefaultAsync(x => x.Email == "superadmin@aspnetmvc.com");
			
			// hanya user biasa yang kita tampilkan
			if (superAdminUser is not null)
			{
				users.Remove(superAdminUser);
			}

			return users;
		}
	}
}
