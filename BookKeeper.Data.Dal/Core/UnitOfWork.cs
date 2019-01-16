using System;
using System.Data.Entity;
using System.Threading.Tasks;
using BookKeeper.Data.Model.Core;

namespace BookKeeper.Data.Dal.Core
{
	public class UnitOfWork : IUnitOfWork
	{
		private DbContext _context;

		public UnitOfWork(DbContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			_context = context;
		}

		public int SaveChanges()
		{
			if (_context == null)
				throw new ObjectDisposedException("context");

			return _context.SaveChanges();
		}

		public Task<int> SaveChangesAsync()
		{
			if (_context == null)
				throw new ObjectDisposedException("context");

			return _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
				_context = null;
			}
		}
	}
}
