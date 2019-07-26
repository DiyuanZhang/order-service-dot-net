using System.Collections.Generic;

namespace order_service.Applications
{
    public class CreateOrderRequest
    {
        public List<CreateOrderItemRequest> OrderItems { get; set; }
    }

    public class CreateOrderItemRequest
    {
        public string Name { get; set; }
    }
}
