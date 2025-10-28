using AutoMapper;
using AnimalAPI.DTOs.Animal;
using AnimalAPI.Models;
using System.Security;

namespace AnimalAPI.Services.AnimalService
{
    public class AnimalService : IAnimalService
    {
        private static List<Animal> Animals = new List<Animal>()
        {
            new Animal(){Name = "Dog"},
            new Animal(){Name = "Cat"}
        };

        public IMapper Mapper { get; }

        public AnimalService(IMapper mapper)
        {
            Mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetAnimalDTO>>> AddAnimal(AddAnimalDTO newAnimal)
        {
            var serviceResponse = new ServiceResponse<List<GetAnimalDTO>>();
            var Animal = Mapper.Map<Animal>(newAnimal);
            
            Animals.Add(Animal);
            serviceResponse.Data = Animals.Select( c => Mapper.Map<GetAnimalDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAnimalDTO>>> GetAllAnimals()
        {
            var serviceResponse = new ServiceResponse<List<GetAnimalDTO>>();
            serviceResponse.Data = Animals.Select(c => Mapper.Map<GetAnimalDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAnimalDTO>> GetAnimal(string name)
        {
            var serviceResponse = new ServiceResponse<GetAnimalDTO>();
            var Animal = Animals.FirstOrDefault(x => x.Name == name);
            serviceResponse.Data = Mapper.Map<GetAnimalDTO>(Animal);

            if (serviceResponse.Data == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Animal not found!";
                //throw new Exception("");
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAnimalDTO>> UpdateAnimal(UpdateAnimalDTO updatedAnimal)
        {
            var serviceResponse = new ServiceResponse<GetAnimalDTO>();
            //treat Animal not found


            var Animal = Animals.FirstOrDefault(x => x.Name.ToLowerInvariant() == updatedAnimal.Name.ToLowerInvariant());


            if (Animal == null)
            {
                throw new Exception($"Animal with {updatedAnimal.Name} not found");
            }

            Animal = Mapper.Map(updatedAnimal, Animal);



            serviceResponse.Data = Mapper.Map<GetAnimalDTO>(Animal);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAnimalDTO>>> DeleteAnimal(DeleteAnimalDTO deleteAnimal)
        {
            var serviceResponse = new ServiceResponse<List<GetAnimalDTO>>();
            var Animal = Animals.FirstOrDefault(c => c.Name.ToLowerInvariant() == deleteAnimal.Name.ToLowerInvariant());

            if (Animal == null)
            {
                throw new Exception($"Animal with {deleteAnimal.Name} not found");
            }

            Animals.Remove(Animal);

            serviceResponse.Data = Animals.Select(c => Mapper.Map<GetAnimalDTO>(c)).ToList();
            return serviceResponse;
        }
    }
}
