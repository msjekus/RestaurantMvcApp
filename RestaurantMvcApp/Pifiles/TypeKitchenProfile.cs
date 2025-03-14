using AutoMapper;
using RestaurantMvcApp.Models;
using RestaurantMvcApp.Models.DTOs;

namespace RestaurantMvcApp.Pifiles
{
    public class TypeKitchenProfile : Profile
    {
        public TypeKitchenProfile()
        {
            CreateMap<TypeKitchen, TypeKitchenDTO>().ReverseMap();
          
        }
    }
}
