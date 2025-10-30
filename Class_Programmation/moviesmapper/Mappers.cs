using AutoMapper;
using Class_Programmation.DAL.Models;
using Class_Programmation.DAL.Models.Dtos;

namespace Class_Programmation.moviesmapper
{
    public class Mappers: Profile
    {

        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }
    }
}
