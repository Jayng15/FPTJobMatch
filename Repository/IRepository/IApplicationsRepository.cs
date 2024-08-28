using FptJobMatch.Models;

namespace FptJobMatch.Repository.IRepository
{
	public interface IApplicationsRepository : IRepository<Application>
	{
		void Update(Application entity);
	}
}
