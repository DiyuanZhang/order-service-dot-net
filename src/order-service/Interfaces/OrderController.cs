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
        
        [HttpGet]
        public ActionResult<string> Create()
        {
            orderService.Create(new CreateOrderRequest());
            return "Order Service is OK";
        }
    }
}
