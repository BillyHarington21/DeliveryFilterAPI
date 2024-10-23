using Domen.Entities;
using Domen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        { 
            _orderRepository = orderRepository; 
        }
        public async Task<List<Order>> GetFilteredOrders(FilterParametr filterParametr)
        {
            var orders = await _orderRepository.GetAllOrdersAsync();

            var filteredOrder = orders.Where(
                order => order.District == filterParametr.cityDistrict &&
                         order.DeliveryTime >= filterParametr.FirstDeliveryDateTime &&
                         order.DeliveryTime <= filterParametr.FirstDeliveryDateTime.AddMinutes(30)).ToList();
            return filteredOrder;
            
        }

    }
}
