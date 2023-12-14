using Microsoft.EntityFrameworkCore;
using OrderApp.DataTransferObjects;
using OrderApp.Domain.Services.Interfaces;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Domain.Services
{
    public class OrderService : IOrderService
    {
        public readonly ApoDBContext _dbContext;

        public OrderService(ApoDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateOrder(OrderRequestDto orderRequestDto)
        {
            
        }

        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Order EditOrder(int id, OrderRequestDto orderRequestDto)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetOrders()
        {
            var orders = _dbContext.Orders.AsNoTracking().ToList();
            return orders;
        }
    }
}
