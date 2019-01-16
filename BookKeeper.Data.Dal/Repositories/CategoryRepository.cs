using BookKeeper.Data.Dal.Core;
using BookKeeper.Data.Model.Core;
using BookKeeper.Data.Model.Entities;

namespace BookKeeper.Data.Model.Repositories
{
	public class CategoryRepository : RepositoryBase<Category, int>, ICategoryRepository
	{
		public CategoryRepository(IDataContext<Category, int> context)
			: base(context)
		{
		}
	}
}
