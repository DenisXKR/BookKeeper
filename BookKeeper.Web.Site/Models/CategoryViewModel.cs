using BookKeeper.Data.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookKeeper.Web.Site.Models
{
	public class CategoryViewModel
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public static CategoryViewModel ToViewModel(Category category)
		{
			return new CategoryViewModel
			{
				Id = category.Id,
				Name = category.Name,
			};
		}
	}
}