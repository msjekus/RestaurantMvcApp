using AutoMapper;
using RestaurantMvcApp.Models;
using RestaurantMvcApp.Models.DTOs;
using RestaurantMvcApp.Models.ViewModels;

namespace RestaurantMvcApp.Pifiles
{
    public class RestourantProfile : Profile
    {
        public RestourantProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
            CreateMap<Restaurant, EditRestaurantVM>().ReverseMap();
           
        }
    }
}
