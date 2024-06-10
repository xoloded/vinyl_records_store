using music_library_website.Data.Models;

namespace music_library_website.ViewModels
{
	public class HomePageViewModel
	{
		public IEnumerable<VinylRecord> FavoriteVinylRecords {  get; set; }
	}
}
