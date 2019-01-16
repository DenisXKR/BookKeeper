using System;
using System.Threading.Tasks;

namespace BookKeeper.Data.Model.Core
{
	public interface IUnitOfWork : IDisposable
	{
		int SaveChanges();

		Task<int> SaveChangesAsync();
	}
}
