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
	[RoutePrefix("api/category")]
	public class CategoryController : ApiController
	{
		private readonly ICategoryRepository _repository;
		protected readonly IUnitOfWork _unitOfWork;

		public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
		{
			_repository = categoryRepository;
			_unitOfWork = unitOfWork;
		}

		public IHttpActionResult GetCategory()
		{
			var result = _repository.All().Select(c => CategoryViewModel.ToViewModel(c));
			return Ok(result);
		}

		public IHttpActionResult GetCategoryViewModel(int id)
		{
			var category = _repository.GetById(id);
			if (category == null)
			{
				return NotFound();
			}

			return Ok(CategoryViewModel.ToViewModel(category));
		}

		public async Task<IHttpActionResult> PutCategory(CategoryViewModel category)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var item = _repository.GetById(category.Id);

			if (item == null)
			{
				return NotFound();
			}

			try
			{
				item.Name = category.Name;
				await _unitOfWork.SaveChangesAsync();
				return Ok(item);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IHttpActionResult> PostCategory(CategoryViewModel category)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_repository.Add(new Category { Name = category.Name });
			await _unitOfWork.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
		}

		public async Task<IHttpActionResult> DeleteCategory(int id)
		{
			var category = _repository.GetById(id);
			if (category == null)
			{
				return NotFound();
			}

			_repository.Remove(category);
			await _unitOfWork.SaveChangesAsync();

			return Ok(category);
		}
	}
}