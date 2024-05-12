using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Business.Services.Interfaces;

namespace NamespaceCBlurred.Controllers
{
    [Route("api/Sounds")]
    [ApiController]
    public class SoundController : Controller
    {
        private readonly ISoundService soundService;

        public SoundController(ISoundService soundService)
        {
            this.soundService = soundService;
        }

        [HttpGet("{soundId}", Name = "GetSound")]
        public async Task<IActionResult> GetSound(int soundId)
        {
            try
            {
                var sound = await this.soundService.GetSoundById(soundId);
                if (sound == null)
                {
                    return NotFound();
                }

                return Ok(sound);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSounds()
        {
            try
            {
                var sounds = await this.soundService.GetAllSounds();

                return Ok(sounds);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSound([FromBody] SoundForAddUpdateModel soundModel)
        {
            try
            {
                var addedSound = await this.soundService.AddSound(soundModel);

                return CreatedAtRoute(
                    "GetSound", new { soundId = addedSound.Id }, addedSound);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{soundId}")]
        public async Task<IActionResult> DeleteSound(int soundId)
        {
            try
            {
                var deleted = await this.soundService.DeleteSound(soundId);
                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("{soundId}")]
        public async Task<IActionResult> UpdateSound(int soundId, [FromBody] SoundForAddUpdateModel soundModel)
        {
            try
            {
                var updated = await this.soundService.UpdateSound(soundId, soundModel);
                if (!updated)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
