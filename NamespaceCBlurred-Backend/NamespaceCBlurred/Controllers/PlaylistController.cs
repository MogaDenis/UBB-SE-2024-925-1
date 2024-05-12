using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Business.Services.Interfaces;

namespace NamespaceCBlurred.Controllers
{
    [Route("api/Playlists")]
    [ApiController]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            this.playlistService = playlistService ?? throw new ArgumentNullException(nameof(playlistService));
        }

        [HttpGet("{playlistId}", Name = "GetPlaylist")]
        public async Task<IActionResult> GetPlaylist(int playlistId)
        {
            try
            {
                var playlist = await playlistService.GetPlaylistById(playlistId);
                if (playlist == null)
                {
                    return NotFound();
                }

                return Ok(playlist);
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
        public async Task<IActionResult> GetAllPlaylists()
        {
            try
            {
                var playlists = await playlistService.GetAllPlaylists();

                return Ok(playlists);
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

        [HttpGet("PlaylistsOfUser/{userId}")]
        public async Task<IActionResult> GetAllPlaylistsOfUser(int userId)
        {
            try
            {
                var playlists = await playlistService.GetAllPlaylistsOfUser(userId);

                return Ok(playlists);
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
        public async Task<IActionResult> AddPlaylist([FromBody] PlaylistForAddUpdateModel playlistModel)
        {
            try
            {
                var addedPlaylist = await playlistService.AddPlaylist(playlistModel);

                return CreatedAtRoute(
                    "GetPlaylist", new { playlistId = addedPlaylist.Id }, addedPlaylist);
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

        [HttpDelete("{playlistId}")]
        public async Task<IActionResult> DeletePlaylist(int playlistId)
        {
            try
            {
                var deleted = await playlistService.DeletePlaylist(playlistId);
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

        [HttpPut("{playlistId}")]
        public async Task<IActionResult> UpdatePlaylist(int playlistId, [FromBody] PlaylistForAddUpdateModel playlistModel)
        {
            try
            {
                var updated = await playlistService.UpdatePlaylist(playlistId, playlistModel);
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
