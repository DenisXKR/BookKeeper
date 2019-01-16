using System;
using System.ComponentModel.DataAnnotations;
using BookKeeper.Data.Model.Entities;

namespace BookKeeper.Web.Site.Models
{
	public class ExpenseViewModel
	{
		public int Id { get; set; }

		[Required]
		public int CategoryId { get; set; }

		[Required]
		public DateTime Date { get; set; }

		public string CategoryName { get; set; }

		[Required]
		public decimal Amount { get; set; }

		public static ExpenseViewModel ToViewModel(Expense expense)
		{
			return new ExpenseViewModel
			{
				Id = expense.Id,
				CategoryId = expense.CategoryId,
				Date = expense.Date,
				CategoryName = expense.Category.Name,
				Amount = expense.Amount
			};
		}
	}
}