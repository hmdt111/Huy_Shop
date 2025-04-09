using Do_An.Models;
using Do_An.Repository;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Pattern
{
    public class ProductFacade
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductFacade(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        // Lấy danh sách sản phẩm với các liên kết (Category, Brand)
        public async Task<List<ProductModel>> GetProductsAsync()
        {
            return await _dataContext.Products
                .Include(c => c.Category)
                .Include(b => b.Brand)
                .ToListAsync();
        }

        // Tạo mới sản phẩm
        public async Task<(bool isSuccess, string message, ProductModel product)> CreateProductAsync(ProductModel product)
        {
            // Sinh slug từ tên sản phẩm
            product.Slug = product.Name.Replace(" ", "-");

            // Kiểm tra sản phẩm đã tồn tại
            var existedProduct = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
            if (existedProduct != null)
            {
                return (false, "Sản phẩm đã tồn tại", null);
            }

            // Upload ảnh nếu có
            if (product.ImageUpload != null)
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                string filePath = Path.Combine(uploadsDir, imageName);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageUpload.CopyToAsync(fs);
                }
                product.Image = imageName;
            }

            _dataContext.Add(product);
            await _dataContext.SaveChangesAsync();
            return (true, "Thêm sản phẩm thành công", product);
        }

        // Cập nhật sản phẩm
        public async Task<(bool isSuccess, string message)> EditProductAsync(ProductModel product)
        {
            // Lấy sản phẩm gốc theo Id
            var existedProduct = await _dataContext.Products.FindAsync(product.Id);
            if (existedProduct == null)
            {
                return (false, "Sản phẩm không tồn tại");
            }

            // Sinh lại slug từ tên
            product.Slug = product.Name.Replace(" ", "-");

            // Nếu có ảnh mới thì upload và xóa ảnh cũ
            if (product.ImageUpload != null)
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                string filePath = Path.Combine(uploadsDir, imageName);

                // Xóa ảnh cũ
                string oldFileImage = Path.Combine(uploadsDir, existedProduct.Image);
                try
                {
                    if (System.IO.File.Exists(oldFileImage))
                    {
                        System.IO.File.Delete(oldFileImage);
                    }
                }
                catch (Exception ex)
                {
                    return (false, "Có lỗi xảy ra khi xóa ảnh cũ");
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageUpload.CopyToAsync(fs);
                }
                existedProduct.Image = imageName;
            }

            // Cập nhật các thuộc tính khác
            existedProduct.Name = product.Name;
            existedProduct.Description = product.Description;
            existedProduct.Price = product.Price;
            existedProduct.CategoryId = product.CategoryId;
            existedProduct.BrandId = product.BrandId;

            _dataContext.Update(existedProduct);
            await _dataContext.SaveChangesAsync();
            return (true, "Cập nhật sản phẩm thành công");
        }

        // Xóa sản phẩm
        public async Task<(bool isSuccess, string message)> DeleteProductAsync(long id)
        {
            var product = await _dataContext.Products.FindAsync(id);
            if (product == null)
            {
                return (false, "Sản phẩm không tồn tại");
            }

            // Xóa ảnh sản phẩm
            string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
            string filePath = Path.Combine(uploadsDir, product.Image);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra khi xóa ảnh sản phẩm");
            }

            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
            return (true, "Sản phẩm đã xóa thành công");
        }
    }

}
