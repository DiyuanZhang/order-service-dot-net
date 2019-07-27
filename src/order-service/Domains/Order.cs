using System.Collections.Generic;

namespace order_service.Domains
{
    public class Order
    {
        public virtual long Id { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }
        
        public virtual void SetOrderItems(List<OrderItem> orderItems)
        {
            OrderItems = orderItems.Count > 20 ? new List<OrderItem>() : orderItems;
        }
    }
}
