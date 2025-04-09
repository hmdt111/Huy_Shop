using Do_An.Models;
using Do_An.Repository;

namespace Do_An.Areas.Admin.Models
{
	public class BrandSingleton
	{
		public static BrandSingleton Instance { get; } = new BrandSingleton();

		public List<BrandModel> listBrand { get; } = new List<BrandModel>();
		private BrandSingleton() { }

		public void Init(DataContext _dataContext)
		{
			if (listBrand.Count == 0)
			{
				var items = _dataContext.Brands.OrderByDescending(p => p.Id).ToList();
				foreach (var item in items)
				{
					listBrand.Add(item);
				}
			}



		}
	}
}
