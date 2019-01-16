using BookKeeper.Data.Model.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BookKeeper.Data.Model.Core
{
	public interface IDataContext<TEntity, in TKey> : IDisposable
		where TEntity : IEntity<TKey>
		where TKey : struct, IEquatable<TKey>
	{
		IQueryable<TEntity> DbSet();

		void Add(TEntity entity);

		void ApplyCurrentValues(TEntity item);

		TEntity GetById(TKey id);

		void Remove(TEntity item);

		int SaveChanges();

		Task<int> SaveChangesAsync();

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);

		void RemoveRange(Expression<Func<TEntity, bool>> predicate);

		Task<int> ExecuteStoredProcedure(string procedureName, params object[] parameters);
	}
}
