using FptJobMatch.Models;

namespace FptJobMatch.Repository.IRepository
{
	public interface IPortfoliosRepository : IRepository<Portfolio>
	{
		void Update(Portfolio entity);
	}
}
