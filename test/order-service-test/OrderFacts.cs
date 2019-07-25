﻿using System.Collections.Generic;
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
            var order = new Order(orderItems);
            Assert.Equal(10, order.GetOrderItems().Count);
        }

        [Fact]
        public void should_failed_when_create_order_with_more_than_20_order_items()
        {
            var orderItems = new List<OrderItem>();
            for (int i = 0; i < 30; i++)
            {
                orderItems.Add(new OrderItem());
            }
            var order = new Order(orderItems);
            Assert.Empty(order.GetOrderItems());
        }
    }
}