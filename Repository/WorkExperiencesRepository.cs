using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;

namespace FptJobMatch.Repository
{
	public class WorkExperiencesRepository : Repository<WorkExperience>, IWorkExperiencesRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public WorkExperiencesRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(WorkExperience entity)
		{
			_dbContext.WorkExperiences.Update(entity);
		}
	}
}
