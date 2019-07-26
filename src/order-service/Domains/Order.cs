using System.Collections.Generic;

namespace order_service.Domains
{
    public class Order
    {
        public virtual long Id { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }

        protected Order()
        {
            
        }

        public Order(List<OrderItem> orderItems)
        {
            OrderItems = orderItems.Count > 20 ? new List<OrderItem>() : orderItems;
        }
    }
}
