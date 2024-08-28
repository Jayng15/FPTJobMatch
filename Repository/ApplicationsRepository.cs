using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;

namespace FptJobMatch.Repository
{
	public class ApplicationsRepository:Repository<Application>, IApplicationsRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public ApplicationsRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Application entity)
		{
			_dbContext.Applications.Update(entity);
		}
	}
}
