using Aplication.Services;
using Domen.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryFilterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult> GetFilteredOrders(string district, DateTime firstDataTimeDelivery)
        {
            var filterParametr = new FilterParametr
            {
                cityDistrict = district,
                FirstDeliveryDateTime = firstDataTimeDelivery,
            };

            var filteredOrders = await _orderService.GetFilteredOrders(filterParametr);
            return Ok(filteredOrders);
        }
    }
}
