using Do_An.Models;

namespace Do_An.Pattern
{
    public interface IOrderState
    {
        Task UpdateStatus(OrderModel order);
    }
    //trạng tháng đơn hàng mới
    public class NewOrderState : IOrderState
    {
        
        public async Task UpdateStatus(OrderModel order)
        {
            order.Status = 1;
            Console.WriteLine($"Đơn hàng {order.OrderCode} đang ở trạng thái mới.");
            // Có thể thực hiện các hành động bổ sung khi đơn hàng mới (ví dụ: gửi email xác nhận)
            await Task.CompletedTask;
        }
    }
    //trạng tháng đơn hàng đã xử lý
    public class ProcessedOrderState : IOrderState
    {
        public async Task UpdateStatus(OrderModel order)
        {
            order.Status = 0;
            Console.WriteLine($"Đơn hàng {order.OrderCode} đã được xử lý.");
            // Thực hiện các hành động khác khi đơn hàng đã xử lý (ví dụ: cập nhật giao hàng)
            await Task.CompletedTask;
        }
    }
}
