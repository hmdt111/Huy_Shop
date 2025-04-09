using Do_An.Models;
using Do_An.Repository;

namespace Do_An.Pattern
{
    public class OrderService
    {
        private readonly DataContext _dataContext;
        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string CreateOrder(string userEmail, List<CartItemModel> cartItems)
        {
            var orderCode = Guid.NewGuid().ToString();
            var order = new OrderModel
            {
                OrderCode = orderCode,
                UserName = userEmail,
                Status = 1,
                CreatedDate = DateTime.Now
            };

            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();

            foreach (var cart in cartItems)
            {
                var orderDetail = new OrderDetails
                {
                    UserName = userEmail,
                    OrderCode = orderCode,
                    ProductId = cart.ProductId,
                    Price = cart.Price,
                    Quantity = cart.Quantity
                };
                _dataContext.OrderDetails.Add(orderDetail);
            }

            _dataContext.SaveChanges();
            return orderCode;
        }
    }
}
