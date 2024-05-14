using Microsoft.AspNetCore.Mvc;
using NamespaceCBlurred.Business.Services.Interfaces;
using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Controllers
{
    [Route("api/Creation")]
    [ApiController]
    public class CreationController : Controller
    {
        private readonly ICreationService creationService;

        public CreationController(ICreationService creationService)
        {
            this.creationService = creationService ?? throw new ArgumentNullException(nameof(creationService));
        }

        [HttpGet]
        public IActionResult GetAllSoundsOfCreation()
        {
            try
            {
                var sounds = creationService.GetAllSoundsOfCreation();

                return Ok(sounds);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("allCreations")]
        public async Task<IActionResult> GetAllCreations()
        {
            try
            {
                var creations = await creationService.GetAllCreations();

                return Ok(creations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{creationId}")]
        public async Task<IActionResult> LoadCreation(int creationId)
        {
            try
            {
                await creationService.LoadCreation(creationId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddSoundToCreation(Sound sound)
        {
            try
            {
                creationService.AddSoundToCreation(sound);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{soundId}")]
        public IActionResult DeleteSoundFromCreation(int soundId)
        {
            try
            {
                bool deleted = creationService.DeleteSoundFromCreation(soundId);

                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("{title}")]
        public async Task<IActionResult> SaveCreation(string title)
        {
            try
            {
                await creationService.SaveCreation(title);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
