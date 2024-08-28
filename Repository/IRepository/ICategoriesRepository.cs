using FptJobMatch.Models;

namespace FptJobMatch.Repository.IRepository
{
	public interface ICategoriesRepository:IRepository<Categories>
	{
		void Update(Categories entity);
	}
}
