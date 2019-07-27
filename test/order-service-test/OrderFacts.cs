using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using order_service.Applications;
using order_service.Domains;
using Xunit;

namespace order_service_test
{
    public class OrderFacts : FactBase
    {
        [Fact]
        public void should_success_when_create_order_with_10_order_items()
        {
            var orderItems = new List<OrderItem>();
            for (int i = 0; i < 10; i++)
            {
                orderItems.Add(new OrderItem());
            }
            var order = new Order();
            order.SetOrderItems(orderItems);

            httpClient.PostAsync("api/order", new CreateOrderRequest
            {
                OrderItems = new List<CreateOrderItemRequest>
                {
                    new CreateOrderItemRequest
                    {
                        Name = "A"
                    }
                }
            }, new JsonMediaTypeFormatter());

            var orders = ResolveSession().Query<Order>().ToList();
            Assert.Equal(10, order.OrderItems.Count);
        }

        [Fact]
        public void should_failed_when_create_order_with_more_than_20_order_items()
        {
            var orderItems = new List<OrderItem>();
            for (int i = 0; i < 30; i++)
            {
                orderItems.Add(new OrderItem());
            }
            var order = new Order();
            order.SetOrderItems(orderItems);
            Assert.Empty(order.OrderItems);
        }
    }
}
