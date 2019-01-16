using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using BookKeeper.Data.Model.Core;
using BookKeeper.Data.Model.Entities;
using BookKeeper.Data.Model.Repositories;
using BookKeeper.Web.Site.Models;

namespace BookKeeper.Web.Site.Controllers.Api
{
	[RoutePrefix("api/expenses")]
	public class ExpensesController : ApiController
	{
		private readonly IExpenseRepository _repository;
		protected readonly IUnitOfWork _unitOfWork;

		public ExpensesController(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
		{
			_repository = expenseRepository;
			_unitOfWork = unitOfWork;
		}

		public IHttpActionResult Get()
		{
			var result = _repository.All().Select(e => ExpenseViewModel.ToViewModel(e));
			return Ok(result);
		}

		public IHttpActionResult Get(int id)
		{
			var expense = _repository.GetById(id);
			if (expense == null)
			{
				return NotFound();
			}

			return Ok(ExpenseViewModel.ToViewModel(expense));
		}

		[HttpPut]
		public async Task<IHttpActionResult> Put(ExpenseViewModel expense)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var item = _repository.GetById(expense.Id);

			if (item == null)
			{
				return NotFound();
			}

			try
			{
				item.CategoryId = expense.CategoryId;
				item.Date = expense.Date;
				item.Amount = expense.Amount;
				await _unitOfWork.SaveChangesAsync();
				return Ok(item);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		public async Task<IHttpActionResult> Post(ExpenseViewModel expense)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_repository.Add(new Expense { CategoryId = expense.CategoryId, Amount = expense.Amount, Date = expense.Date });
			await _unitOfWork.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = expense.Id }, expense);
		}

		[HttpDelete]
		public async Task<IHttpActionResult> Delete(int id)
		{
			var expense = _repository.GetById(id);
			if (expense == null)
			{
				return NotFound();
			}

			_repository.Remove(expense);
			await _unitOfWork.SaveChangesAsync();

			return Ok(expense);
		}

		[Route("getexpensebycategory")]
		public IHttpActionResult GetExpenseByCategory()
		{
			var result = _repository.All().GroupBy(g => new { g.CategoryId, g.Category.Name })
				.Select(e => new
				{
					CategoryId = e.Key.CategoryId,
					CategoryName = e.Key.Name,
					Sum = e.Sum(g => g.Amount)
				});

			return Ok(result);
		}

		[Route("getexpensebymonth")]
		public IHttpActionResult GetExpenseByMonth()
		{
			var result = _repository.All().GroupBy(g => new { g.Date.Year, g.Date.Month })
				.Select(e => new
				{
					Year = e.Key.Year,
					Month = e.Key.Month,
					Sum = e.Sum(g => g.Amount)
				})
				.OrderBy(d => d.Year).ThenBy(d => d.Month);

			return Ok(result);
		}
	}
}