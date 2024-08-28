using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;

namespace FptJobMatch.Repository
{
	public class PortfoliosRepository : Repository<Portfolio>, IPortfoliosRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public PortfoliosRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Portfolio entity)
		{
			_dbContext.Portfolios.Update(entity);
		}
	}
}
