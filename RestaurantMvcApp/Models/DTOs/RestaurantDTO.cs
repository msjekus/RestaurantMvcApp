using System.ComponentModel.DataAnnotations;

namespace RestaurantMvcApp.Models.DTOs
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        [Display(Name = "Назва ресторану")]
        public string Name { get; set; } = default!;
       
        public int TypeKitchenId { get; set; }
        [Display(Name = "Адреса")]
        public string Address { get; set; } = default!;
        [Display(Name = "Телефон")]
        public string Telephone { get; set; } = default!;
        [Display(Name = "Години роботи")]
        public string HourOfWork { get; set; } = default!;
        [Display(Name = "Фото/логотип")]
        public byte[]? ImagePath { get; set; } = default!;
        [Display(Name = "Тип кухні")]
        public TypeKitchenDTO? TypeKitchen { get; set; } = default!;
    }
}
