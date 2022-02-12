using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public float Duration { get; set; }

        public DateTime UploadedDate { get; set; }

        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public bool IsFeatured { get; set; }
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        
        [NotMapped]
        public IFormFile? AuditoFile { get; set; }

        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
    }
}
