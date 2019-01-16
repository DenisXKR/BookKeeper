using BookKeeper.Data.Dal.Core;
using BookKeeper.Data.Model.Core;
using BookKeeper.Data.Model.Entities;

namespace BookKeeper.Data.Model.Repositories
{
	public class ExpenseRepository : RepositoryBase<Expense, int>, IExpenseRepository
	{
		public ExpenseRepository(IDataContext<Expense, int> context)
			: base(context)
		{
		}
	}
}
