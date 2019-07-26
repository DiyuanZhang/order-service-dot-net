using System.Linq;
using order_service.Domains;

namespace order_service.Applications
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Create(CreateOrderRequest request)
        {
            var orderItems = request.OrderItems.Select(o => new OrderItem
            {
                Name = o.Name
            }).ToList();
            var order = new Order(orderItems);
            orderRepository.Save(order);
        }
    }
}
