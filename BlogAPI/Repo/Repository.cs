using Microsoft.EntityFrameworkCore;
using BlogAPI.DbOperations;

namespace BlogAPI.Repo
{
	public class Repository<T> : IRepository<T> where T : class
	{
        private readonly BContext context;
        public Repository(BContext context)
        {
            this.context = context;
        }
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await context.Set<T>().ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await context.Set<T>().FindAsync(id);
		}
	}
}
