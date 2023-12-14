using AutoMapper;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.DataTransferObjects.Configurations
{
    public class MapConfigurations : Profile 
    {
        public MapConfigurations()
        {
            CreateMap<Order, OrderResponseDto>();
            CreateMap<OrderRequestDto, Order>();

            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductRequestDto, Product>();

            CreateMap<OrderDetail, OrderDetailResponseDto>();
            CreateMap<OrderDetailRequestDto, OrderDetail>();
        }
            
    }
}
