using FptJobMatch.Models;

namespace FptJobMatch.Repository.IRepository
{
	public interface IJobsRepository : IRepository<Job>
	{
		void Update(Job entity);
	}
}
