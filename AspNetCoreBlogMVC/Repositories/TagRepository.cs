using AspNetCoreBlogMVC.Data;
using AspNetCoreBlogMVC.Models.Domain;
using AspNetCoreBlogMVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBlogMVC.Repositories
{
    public class TagRepository : ITagRepository
    {
		private readonly BlogDbContext blogDbContext;

		public TagRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
		}
		public async Task<IEnumerable<Tag>> GetAllAsync(
			string? searchQuery,
			string? sortBy,
			string? sortDirection
		)
		{
			var query = blogDbContext.Tags.AsQueryable();

			// Filtering
			if (string.IsNullOrWhiteSpace(searchQuery) == false)
			{
				query = query.Where(x => x.Name.Contains(searchQuery) ||
										 x.DisplayName.Contains(searchQuery));
			}

			// Sorting
			if (string.IsNullOrWhiteSpace(sortBy) == false)
			{
				var isDesc = string.Equals(sortDirection, "Desc", StringComparison.OrdinalIgnoreCase);

				if (string.Equals(sortBy, "Name", StringComparison.OrdinalIgnoreCase))
				{
					query = isDesc ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
				}

				if (string.Equals(sortBy, "DisplayName", StringComparison.OrdinalIgnoreCase))
				{
					query = isDesc ? query.OrderByDescending(x => x.DisplayName) : query.OrderBy(x => x.DisplayName);
				}
			}

			// Pagination


			return await query.ToListAsync();

			//return await blogDbContext.Tags.ToListAsync();
		}

		public async Task<Tag> AddAsync(Tag tag)
        {
			await blogDbContext.Tags.AddAsync(tag);
			await blogDbContext.SaveChangesAsync();

            return tag;
		}

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await blogDbContext.Tags.FindAsync(id);
			if (existingTag != null)
			{
				blogDbContext.Tags.Remove(existingTag);
				await blogDbContext.SaveChangesAsync();
				return existingTag;
			}
			return null;
		}

        public Task<Tag?> GetAsync(Guid id)
        {
			return blogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
		}

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
			var existingTag = await blogDbContext.Tags.FindAsync(tag.Id);
			if (existingTag != null)
			{
				existingTag.Name = tag.Name;
				existingTag.DisplayName = tag.DisplayName;

				// save changes 
				await blogDbContext.SaveChangesAsync();

				return existingTag;
			}

			return null;
		}
		public Task<int> CountAsync()
		{
			throw new NotImplementedException();
		}
	}
}
