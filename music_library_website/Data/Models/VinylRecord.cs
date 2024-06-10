using System.ComponentModel.DataAnnotations.Schema;

namespace music_library_website.Data.Models
{
	public class VinylRecord
    {
        public long Id { get; set; }
        public string Singer { get; set; }
        public string Album { get; set; }
        public int YearOfRelease { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool Available { get; set; }
		
        [ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; }
		public long CategoryId { get; set; }
	}
}
