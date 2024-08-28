using FptJobMatch.Models;

namespace FptJobMatch.Repository.IRepository
{
	public interface IAwardsRepository : IRepository<Award>
	{
		void Update(Award entity);
	}
}
