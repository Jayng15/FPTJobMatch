using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;

namespace FptJobMatch.Repository
{
	public class UsersRepository : Repository<ApplicationUser>, IUsersRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public UsersRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(ApplicationUser entity)
		{
			_dbContext.Users.Update(entity);
		}
	}
}
