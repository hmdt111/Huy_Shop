using Do_An.Models;
using Do_An.Repository;

namespace Do_An.Pattern
{
    public class CartBuilder
    {
        private List<CartItemModel> _cart;

        public CartBuilder(ISession session)
        {
            _cart = session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
        }

        public CartBuilder AddItem(ProductModel product)
        {
            var cartItem = _cart.FirstOrDefault(p => p.ProductId == product.Id);
            if (cartItem == null)
            {
                cartItem = new CartItemBuilder(product).Build();
                _cart.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            return this;
        }

        public CartBuilder IncreaseQuantity(int productId)
        {
            var cartItem = _cart.FirstOrDefault(p => p.ProductId == productId);
            if (cartItem != null) cartItem.Quantity++;
            return this;
        }

        public CartBuilder DecreaseQuantity(int productId)
        {
            var cartItem = _cart.FirstOrDefault(p => p.ProductId == productId);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                    cartItem.Quantity--;
                else
                    _cart.Remove(cartItem);
            }
            return this;
        }

        public CartBuilder RemoveItem(int productId)
        {
            _cart.RemoveAll(p => p.ProductId == productId);
            return this;
        }

        public CartBuilder ClearCart()
        {
            _cart.Clear();
            return this;
        }

        public void Save(ISession session)
        {
            if (_cart.Count == 0)
                session.Remove("Cart");
            else
                session.SetJson("Cart", _cart);
        }

        public List<CartItemModel> GetCart() => _cart;
    }
}
