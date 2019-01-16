using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Model.Entities
{
	public class Category : IEntity<int>
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}
