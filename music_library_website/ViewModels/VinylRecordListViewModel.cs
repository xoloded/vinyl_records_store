using music_library_website.Data.Models;

namespace music_library_website.ViewModels
{
	public class VinylRecordListViewModel
	{
		public IEnumerable<VinylRecord> AllVinylRecords { get; set; }
		public string CurrentCategory { get; set; }
	}
}
