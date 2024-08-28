using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;

namespace FptJobMatch.Repository
{
	public class EducationsRepository : Repository<Education>, IEducationsRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public EducationsRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Education entity)
		{
			_dbContext.Educations.Update(entity);
		}
	}
}
