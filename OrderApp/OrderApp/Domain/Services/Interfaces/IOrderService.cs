using OrderApp.DataTransferObjects;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Domain.Services.Interfaces
{
    public interface IOrderService
    {
        ICollection<Order> GetOrders();
        bool CreateOrder(OrderRequestDto orderRequestDto);
        Order EditOrder(int id, OrderRequestDto orderRequestDto);
        bool DeleteOrder(int id);

        Order GetOrder(int id);
    }
}
