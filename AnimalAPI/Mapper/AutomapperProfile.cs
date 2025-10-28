using AutoMapper;
using AnimalAPI.DTOs.Animal;
using AnimalAPI.Models;

namespace AnimalAPI.Mapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Animal, GetAnimalDTO>();
            CreateMap<AddAnimalDTO, Animal>();
            CreateMap<UpdateAnimalDTO, Animal>();
        }
    }
}
