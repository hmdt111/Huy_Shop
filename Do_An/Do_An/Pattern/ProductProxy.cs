using Do_An.Models;
using Do_An.Repository;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Pattern
{
    public class ProductProxy
    {
        private readonly DataContext _dataContext;
        private ProductModel _cachedProduct;

        public ProductProxy(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            // Nếu đã có trong cache, trả về sản phẩm từ cache
            if (_cachedProduct != null && _cachedProduct.Id == id)
            {
                return _cachedProduct;
            }

            // Nếu không có trong cache, truy vấn cơ sở dữ liệu
            _cachedProduct = await _dataContext.Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return _cachedProduct;
        }
    }
}
