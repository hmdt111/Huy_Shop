using Do_An.Pattern;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_An.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string OrderCode { get; set; }

        public string UserName { get; set; }    

        public DateTime CreatedDate { get; set; }   

        public int Status { get; set; }
        [NotMapped]
        public IOrderState CurrentState { get; set; }
        public async Task UpdateOrderStatus()
        {
            await CurrentState.UpdateStatus(this);
        }

        // Đặt trạng thái mới cho đơn hàng
        public void SetState(IOrderState state)
        {
            CurrentState = state;
        }
    }
}
