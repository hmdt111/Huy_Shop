using Do_An.Models;

namespace Do_An.Pattern
{
    public class ProductIterator : IIterator<ProductModel>
    {
        private readonly List<ProductModel> _products;
        private int _position = 0;

        public ProductIterator(List<ProductModel> products)
        {
            _products = products;
        }

        public bool HasNext()
        {
            return _position < _products.Count;
        }

        public ProductModel Next()
        {
            return HasNext() ? _products[_position++] : null;
        }
    }
}
