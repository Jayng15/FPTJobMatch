using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;

namespace FptJobMatch.Repository
{
	public class JobsRepository : Repository<Job>, IJobsRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public JobsRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Job entity)
		{
			_dbContext.Jobs.Update(entity);
		}
	}
}
