using Do_An.Models;

namespace Do_An.Pattern
{
    public class CartItemBuilder
    {
        private readonly CartItemModel _cartItem;
        // Tạo  bắt đầu với một sản phẩm (ProductModel).
        public CartItemBuilder(ProductModel product)
        {
            _cartItem = new CartItemModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                Image = product.Image
            };
        }

        //Có thể chỉnh sửa số lượng (SetQuantity).
        public CartItemBuilder SetQuantity(int quantity)
        {
            _cartItem.Quantity = quantity;
            return this;
        }

        //Build() để tạo đối tượng CartItemModel.
        public CartItemModel Build()
        {
            return _cartItem;
        }
    }
}
