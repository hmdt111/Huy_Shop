using Do_An.Models;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Repository
{
	public class SeedData
	{
		//public static void SeedingData(DataContext _context)
		//{
		//	_context.Database.Migrate();
		//	if (!_context.Products.Any())
		//	{
		//		CategoryModel macbook = new CategoryModel { Name = "Macbook", Slug = "macbook", Description = "Macbook is large Product in the world", Status = 1 };
		//		CategoryModel pc = new CategoryModel { Name = "Pc", Slug = "pc", Description = "Pc is large Product in the world", Status = 1 };
		//		BrandModel apple = new BrandModel { Name = "Apple", Slug = "apple", Description = "Apple is large Brand in the world", Status = 1 };
		//		BrandModel samsung = new BrandModel { Name = "SamSung", Slug = "samsung", Description = "SamSung is large Brand in the world", Status = 1 };
		//		_context.Products.AddRange(
		//			new ProductModel { Name = "Macbook", Slug = "macbook", Description = "Macbook is the Best", Image = "1.jpg", Category = macbook, Brand = apple, Price = 24000000 },
		//			new ProductModel { Name = "Pc", Slug = "pc", Description = "Pc is the Best", Image = "1.jpg", Category = pc, Brand = samsung, Price = 24000000 }
		//		);
		//		_context.SaveChanges();
		//	}
		//}
	}
}
