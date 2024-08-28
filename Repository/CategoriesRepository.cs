using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;

namespace FptJobMatch.Repository
{
	public class CategoriesRepository : Repository<Categories>, ICategoriesRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public CategoriesRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Categories entity)
		{
			_dbContext.Categories.Update(entity);
		}
	}
}
