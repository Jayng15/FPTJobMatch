using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FptJobMatch.Repository
{
	public class AwardsRepository : Repository<Award>, IAwardsRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public AwardsRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Award entity)
		{
			_dbContext.Awards.Update(entity);
		}
	}
}
