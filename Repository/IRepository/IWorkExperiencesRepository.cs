using FptJobMatch.Models;

namespace FptJobMatch.Repository.IRepository
{
	public interface IWorkExperiencesRepository : IRepository<WorkExperience>
	{
		void Update(WorkExperience entity);
	}
}
