using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Model.Entities
{
	public class Expense : IEntity<int>
	{
		public int Id { get; set; }

		public int CategoryId { get; set; }

		public DateTime Date { get; set; }

		public decimal Amount { get; set; }

		public virtual Category Category { get; set; }
	}
}
