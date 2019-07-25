using System.Collections.Generic;

namespace order_service.Domains
{
    public class Order
    {
        private List<OrderItem> orderItems;
        public Order(List<OrderItem> orderItems)
        {
            this.orderItems = orderItems.Count > 20 ? new List<OrderItem>() : orderItems;
        }

        public List<OrderItem> GetOrderItems()
        {
            return this.orderItems;
        }
    }
}
