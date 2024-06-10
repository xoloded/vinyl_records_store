namespace music_library_website.Data.Models
{
    public enum CategoryTypesOfMusic
    {
        None,
        Rock,
        Pop,
        HipHop
    }

    public class Category
    {
        public long Id { get; set; }
        public CategoryTypesOfMusic TypesOfMusic { get; set; }
        public string Description { get; set; }
        public List<VinylRecord> VinylRecords { get; set; }
    }
}
