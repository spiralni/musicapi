using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Models;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApiDbContext _db;

        public SongsController(ApiDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var songs = await _db.Songs.ToListAsync();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _db.Songs.FindAsync(id);

            if (song != null)
            {
                return Ok(song);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Song song)
        {
            _db.Songs.Add(song);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Song song)
        {
            Song? found = await _db.Songs.FindAsync(id);

            if (found != null)
            {
                found.Title = song.Title;
                found.Language = song.Language;
                found.Duration = song.Duration;

                await _db.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Song? found = await _db.Songs.FindAsync(id);

            if (found != null)
            {
                _db.Songs.Remove(found);
                await _db.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        [HttpGet("[action]/{id}")]
        public int Echo(int id)
        {
            return id;
        }
    }
}
