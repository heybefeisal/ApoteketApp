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

        public Order GetOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(x => x.OrderId == id);
            return order;
        }

        public ICollection<Order> GetOrders()
        {
            var orders = _dbContext.Orders.AsNoTracking().ToList();
            return orders;
        }
        public bool CreateOrder(OrderRequestDto orderRequestDto)
        {
            var order = _dbContext.Orders.AsNoTracking().Any(x => x.OrderDate == orderRequestDto.OrderDate);

            if(order)
            {
                return false;
            }

            var newOrder = new Order
            {
                OrderDate = orderRequestDto.OrderDate
            };
            _dbContext.Add(newOrder);

            if(_dbContext.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }

        public bool DeleteOrder(int id)
        {
            var delete = _dbContext.Orders.FirstOrDefault(x => x.OrderId == id);
            if(delete == null)
            {
                return false;
            }

            _dbContext.Orders.Remove(delete);

            if(_dbContext.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }

        public Order EditOrder(int id, OrderRequestDto orderRequestDto)
        {
            var order = _dbContext.Orders.FirstOrDefault(x => x.OrderId == id);
            if(order == null)
            {
                return null;
            }

            order.OrderDate = orderRequestDto.OrderDate;
            if(_dbContext.SaveChanges() == 1)
            {
                return order;
            }

            return null;
            
        }

    }
}
