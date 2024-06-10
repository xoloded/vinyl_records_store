using Microsoft.AspNetCore.Mvc;
using music_library_website.Data.Interfaces;
using music_library_website.ViewModels;

namespace music_library_website.Controllers
{
	public class HomeController : Controller
	{
		private IAllVinylRecords _vinylRecordRepository;
		public HomeController(IAllVinylRecords vinylRecordRepository)
		{
			_vinylRecordRepository = vinylRecordRepository;
		}
		public ViewResult Index()
		{
			var favoriteVinylRecords = new HomePageViewModel
			{
				FavoriteVinylRecords = _vinylRecordRepository.GetFavoriteVinylRecords
			};
			return View(favoriteVinylRecords);
		}
	}
}
