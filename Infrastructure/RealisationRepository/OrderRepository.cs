using Domen.Entities;
using Domen.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.RealisationRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _filePath;

        public OrderRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            using (var reader = new StreamReader(_filePath))
            {
                var json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();
            }
        }

        public async Task<Order?> GetOrderById(int Id)
        { 
            var orders = await GetAllOrdersAsync();
            return orders.FirstOrDefault(order => order.Id == Id);
        }

        public async Task AddOrder(Order order)
        {
            var orders = await GetAllOrdersAsync();
            orders.Add(order);

            using ( var writer = new StreamWriter(_filePath))
            {
                var json = JsonConvert.SerializeObject(orders, Formatting.Indented);
                await writer.WriteAsync(json);
            }
        }
    }
}
