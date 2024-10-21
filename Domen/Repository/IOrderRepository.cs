using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GerAllOrders();
        Task<Order?> GerOrderById(Order order);
        Task AddOrder(Order order);
    }
}
