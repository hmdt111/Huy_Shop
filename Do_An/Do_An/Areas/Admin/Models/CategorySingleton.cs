using Do_An.Models;
using Do_An.Repository;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Areas.Admin.Models
{
	public sealed class CategorySingleton
	{
		public static CategorySingleton Instance { get; } = new CategorySingleton();

		public List<CategoryModel> listCategory { get; } = new List<CategoryModel>();
		private CategorySingleton() { }

		public void Init(DataContext _dataContext)
		{
			if (listCategory.Count == 0)
			{
				var items = _dataContext.Categories.OrderByDescending(p => p.Id).ToList();
				foreach (var item in items)
				{
					listCategory.Add(item);
				}
			}

			

		}
	}
}
