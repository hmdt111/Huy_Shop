using Do_An.Models;

namespace Do_An.Pattern
{
    public class ProductCollection : ICollection<ProductModel>
    {
        private readonly List<ProductModel> _products = new List<ProductModel>();

        public void AddProduct(ProductModel product)
        {
            _products.Add(product);
        }

        public IIterator<ProductModel> CreateIterator()
        {
            return new ProductIterator(_products);
        }
    }
}
