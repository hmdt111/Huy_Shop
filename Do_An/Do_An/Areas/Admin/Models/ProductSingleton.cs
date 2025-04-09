using Do_An.Models;
using Do_An.Repository;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Areas.Admin.Models
{
    public sealed class ProductSingleton
    {
        public static ProductSingleton Instance { get; } = new ProductSingleton();

        public List<ProductModel> listProduct { get; } = new List<ProductModel>();
        private ProductSingleton() { }

        public async Task<List<ProductModel>> Init(DataContext _dataContext)
        {
            if(listProduct.Count == 0)
            {
                var items =await _dataContext.Products.OrderByDescending(p => p.Id).Include(p => p.Category).Include(p => p.Brand).ToListAsync();
                foreach(var item in items)
                {
                    listProduct.Add(item);
                }
            } 

            return listProduct;
           
        }
    }
}
