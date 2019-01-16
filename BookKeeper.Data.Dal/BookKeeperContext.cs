using BookKeeper.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Dal
{
	public class BookKeeperContext : DbContext
	{
		public DbSet<Expense> Expense { get; set; }
		public DbSet<Category> Category { get; set; }
	}
}
