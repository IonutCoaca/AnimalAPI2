using AnimalAPI.Models;

namespace AnimalAPI.DTOs.Animal
{
    public class UpdateAnimalDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Species { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public double Height { get; set; } = 0.0;
        // what is the position obj used for?
    }
}
