using AnimalAPI.DTOs.Animal;
using AnimalAPI.Models;
using AnimalAPI.Services.AnimalService;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController:ControllerBase
    {
        private IAnimalService AnimalService { get; set; }
        public AnimalController(IAnimalService AnimalService) // applied dependency injection in ctr
        {
            this.AnimalService  = AnimalService;
        }

        [HttpGet("/GetAll")] 
        public async Task<ActionResult<ServiceResponse<List<GetAnimalDTO>>>> GetAll() 
        {
            
            return Ok( await AnimalService.GetAllAnimals());
        }
        [HttpGet("/Single/{name}")]
        public async  Task<ActionResult<ServiceResponse<GetAnimalDTO>>> GetSingle(string name)
        {
            var result = await AnimalService.GetAnimal(name);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost("/AddAnimal")]

        public async Task<ActionResult<ServiceResponse<List<GetAnimalDTO>>>> AddAnimal (AddAnimalDTO newAnimal)
        {
            return Ok( await AnimalService.AddAnimal(newAnimal));
        }
        [HttpPut("/UpdateAnimal")]
        public async Task<ActionResult<ServiceResponse<GetAnimalDTO>>> UpdateAnimal(UpdateAnimalDTO newAnimal)
        {
            return Ok(await AnimalService.UpdateAnimal(newAnimal));
        }
        [HttpDelete("/DeleteAnimal")]
        public async Task<ActionResult<ServiceResponse<GetAnimalDTO>>> DeleteAnimal(DeleteAnimalDTO newAnimal)
        {
            return Ok(await AnimalService.DeleteAnimal(newAnimal));
        }
    }
}
