using Microsoft.AspNetCore.Mvc;
using order_service.Applications;

namespace order_service.Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }
        
        [HttpPost]
        public ActionResult<string> Create(CreateOrderRequest request)
        {
            orderService.Create(request);
            return "Order Service is OK";
        }
    }
}
