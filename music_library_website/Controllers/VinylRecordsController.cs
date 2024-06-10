using Microsoft.AspNetCore.Mvc;
using music_library_website.Data.Interfaces;
using music_library_website.Data.Repository;
using music_library_website.ViewModels;

namespace music_library_website.Controllers
{
    public class VinylRecordsController : Controller
    {
        private readonly IAllVinylRecords _allVinylRecords;
        private readonly IAllVinylRecordsCategory _allVinylRecordsCategory;
        public VinylRecordsController(IAllVinylRecords allVinylRecords, IAllVinylRecordsCategory allVinylRecordsCategory)
        {
            _allVinylRecords = allVinylRecords;
            _allVinylRecordsCategory = allVinylRecordsCategory;
        }

        [Route("VinylRecords/ViewResult")]
		[Route("VinylRecords/ViewResult/{typesOfMusic}")]
		public ViewResult ViewResult(string typesOfMusic)
        {
            var objVinylRecords = new VinylRecordListViewModel();
            if (!string.IsNullOrEmpty(typesOfMusic))
            {
                switch (typesOfMusic)
                {
                    case "Rock":
                        objVinylRecords.AllVinylRecords = _allVinylRecords.VinylRecords
                            .Where(e => e.Category.TypesOfMusic == Data.Models.CategoryTypesOfMusic.Rock);
                        objVinylRecords.CurrentCategory = "Рок";
                        break;
                    case "Pop":
                        objVinylRecords.AllVinylRecords = _allVinylRecords.VinylRecords
                            .Where(e => e.Category.TypesOfMusic == Data.Models.CategoryTypesOfMusic.Pop);
                        objVinylRecords.CurrentCategory = "Поп";
                        break;
                    case "HipHop":
                        objVinylRecords.AllVinylRecords = _allVinylRecords.VinylRecords
                            .Where(e => e.Category.TypesOfMusic == Data.Models.CategoryTypesOfMusic.HipHop);
                        objVinylRecords.CurrentCategory = "Хип Хоп";
                        break;
                }
            }
            else
            {
                objVinylRecords.AllVinylRecords = _allVinylRecords.VinylRecords;
				objVinylRecords.CurrentCategory = "Все жанры";
			}
			ViewBag.Title = "Страница с виниловыми пластинками";
			return View(objVinylRecords);
        }

        public ViewResult ViewItem(int id)
        {
            var vinylRecord = _allVinylRecords.VinylRecords.FirstOrDefault(e => e.Id == id);

            if (vinylRecord != null)
            {
                return View(vinylRecord);
			}
            return View(null); 
        }

        public ViewResult AddVinylRecord()
        {
            _allVinylRecords.AddVinylRecordsInDataBase();
            return View();
        }
    }
}
