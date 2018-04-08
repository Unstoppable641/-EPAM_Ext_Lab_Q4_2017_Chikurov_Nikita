using System;
using AutoMapper;
using DAL.Components;
using Task01.Models;

namespace Task01.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderView>()
               .ForMember(
               dest => dest.OrderStatus,
               opt => opt.MapFrom(src => Enum.GetName(
                   typeof(OrderStatus),
                   src.OrderState))));
        }
    }
}