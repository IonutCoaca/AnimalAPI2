using System.Text.Json.Serialization;

namespace AnimalAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] // this sends the name of the enum elements instead of the values
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3,
    }
}
