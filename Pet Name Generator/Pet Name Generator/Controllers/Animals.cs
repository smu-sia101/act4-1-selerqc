using Microsoft.AspNetCore.Mvc;
using Pet_Name_Generator.Constants;

namespace Pet_Name_Generator.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class Animals : ControllerBase
    {
        private readonly string[] dog = new string[]{
          "Buddy", "Max", "Charlie","Rocky", "Rex"
        };
        private readonly string[] cat = new string[]
        {
            "Whiskers","Mittens","Luna","Simba","Tiger"
        };
        private readonly string[] bird = new string[]
        {
            "Tweety","Sky","Chirpy","Raven","Sunny"
        };

        [HttpPost("/generate/animalType")]
        public IActionResult Post(string animalType, Boolean twoType)
        {
            Random rnd = new();
            if (string.IsNullOrEmpty(animalType))
            {
                return BadRequest(new
                {
                    error = string.Format(Messages.RequiredMessage, nameof(animalType))
                });
            };
            string[] selectedPet;
            switch (animalType.ToLower())
            {
                case "dog": selectedPet = dog; break;
                case "cat": selectedPet = cat; break;
                case "bird": selectedPet = bird; break;
                default:
                    return BadRequest(new
                    {
                        error = string.Format(Messages.InvalidType, "dog,cat,bird")
                    });
            };

            string name1 = selectedPet[rnd.Next(selectedPet.Length)];

            if (twoType)
            {
                string name2 = selectedPet[rnd.Next(selectedPet.Length)];
                return Ok(new
                {
                    name = string.Format(Messages.Success, $"{name1}{name2}")
                });
            }
            else
            {
                return Ok(new
                {
                    name = name1
                });
            }
        }
    }
}
