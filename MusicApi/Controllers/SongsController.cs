using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly List<Song> songList = new List<Song>() {
            new Song() { Id = 1, Title="Song 1", Language="English"},
            new Song() { Id = 2, Title="Song 2", Language="English"},
            new Song() { Id = 3, Title="Song 3", Language="Spanish"},
        };

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return songList;
        }

        [HttpPost]
        public void Post(Song song)
        {
            songList.Add(song);
        }

        [HttpPut("{id}")]
        public void Put(int id, Song song)
        {
            Song? found = songList.Find(s => s.Id == id);

            if (found != null) 
            { 
                found.Title = song.Title;
                found.Language = song.Language;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Song? found = songList.Find(s => s.Id == id);

            if (found != null)
            {
                songList.Remove(found);
            }
        }
    }
}
