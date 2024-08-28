using FptJobMatch.Models;

namespace FptJobMatch.Repository.IRepository
{
	public interface IEducationsRepository : IRepository<Education>
	{
		void Update (Education entity);
	}
}
