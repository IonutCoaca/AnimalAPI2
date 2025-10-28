using AnimalAPI.DTOs.Animal;
using AnimalAPI.Models;

namespace AnimalAPI.Services.AnimalService
{
    public interface IAnimalService
    {
        Task<ServiceResponse<List<GetAnimalDTO>>> GetAllAnimals();
        Task<ServiceResponse<GetAnimalDTO>> GetAnimal(string Name);
        Task<ServiceResponse<List<GetAnimalDTO>>> AddAnimal(AddAnimalDTO Animal);
        Task<ServiceResponse<List<GetAnimalDTO>>> DeleteAnimal(DeleteAnimalDTO Animal);
        Task<ServiceResponse<GetAnimalDTO>> UpdateAnimal(UpdateAnimalDTO Animal);
    }
}
