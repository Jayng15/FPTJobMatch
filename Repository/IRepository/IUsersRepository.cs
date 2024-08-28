using FptJobMatch.Models;

namespace FptJobMatch.Repository.IRepository
{
	public interface IUsersRepository : IRepository<ApplicationUser>
	{
		void Update(ApplicationUser entity);
	}
}
