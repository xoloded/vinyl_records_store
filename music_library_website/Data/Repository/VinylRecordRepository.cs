using Microsoft.EntityFrameworkCore;
using music_library_website.Data.Interfaces;
using music_library_website.Data.Models;

namespace music_library_website.Data.Repository
{
    public class VinylRecordRepository : IAllVinylRecords
    {
        private readonly AppDBContext appDBContext;
        public VinylRecordRepository(AppDBContext appDBContent)
        {
            this.appDBContext = appDBContent;
        }
        public IEnumerable<VinylRecord> VinylRecords => appDBContext.VinylRecords.Include(e => e.Category);
        public IEnumerable<VinylRecord> GetFavoriteVinylRecords => appDBContext.VinylRecords.Where(e => e.IsFavorite == true).Include(e => e.Category);
        public VinylRecord GetObjectVinylRecord(int vinylRecordId) => appDBContext.VinylRecords.FirstOrDefault(e => e.Id == vinylRecordId);
        public void AddVinylRecordsInDataBase()
        {
   //         var category = new Category
   //         {
   //             TypesOfMusic = CategoryTypesOfMusic.Rock,
   //             Description = "Описание"
   //         };
   //         var vinylRecord = new VinylRecord
   //         {
   //             Singer = "Rammstein",
   //             Album = "Mutter",
   //             YearOfRelease = 2001,
   //             Description = "Описание",
   //             Image = "/img/3_0.jpg",
   //             Price = 10000,
   //             IsFavorite = true,
   //             Available = true,
   //             Category = category,
   //         };
   //         appDBContext.Add(vinylRecord);

			//var category1 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.Pop,
			//	Description = "Описание"
			//};
			//var vinylRecord1 = new VinylRecord
			//{
			//	Singer = "Charli XCX",
			//	Album = "How I'm Feeling Now",
			//	YearOfRelease = 2020,
			//	Description = "Описание",
			//	Image = "/img/0_0.jpg",
			//	Price = 4800,
			//	IsFavorite = true,
			//	Available = true,
			//	Category = category1,
			//};
			//appDBContext.Add(vinylRecord1);

			//var category2 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.Rock,
			//	Description = "Описание"
			//};
			//var vinylRecord2 = new VinylRecord
			//{
			//	Singer = "Slipknot",
			//	Album = "Vol. 3: (The Subliminal Verses)",
			//	YearOfRelease = 2004,
			//	Description = "Описание",
			//	Image = "/img/1_0.jpg",
			//	Price = 6500,
			//	IsFavorite = false,
			//	Available = true,
			//	Category = category2,
			//};
			//appDBContext.Add(vinylRecord2);

			//var category3 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.HipHop,
			//	Description = "Описание"
			//};
			//var vinylRecord3 = new VinylRecord
			//{
			//	Singer = "Joji",
			//	Album = "Ballads 1",
			//	YearOfRelease = 2018,
			//	Description = "Описание",
			//	Image = "/img/2_0.jpg",
			//	Price = 6500,
			//	IsFavorite = true,
			//	Available = true,
			//	Category = category3,
			//};
			//appDBContext.Add(vinylRecord3);

			//var category4 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.HipHop,
			//	Description = "Описание"
			//};
			//var vinylRecord4 = new VinylRecord
			//{
			//	Singer = "Post Malone",
			//	Album = "Hollywood's Bleeding (Pink Vinyl)",
			//	YearOfRelease = 2019,
			//	Description = "Описание",
			//	Image = "/img/4_0.jpg",
			//	Price = 6500,
			//	IsFavorite = false,
			//	Available = true,
			//	Category = category4,
			//};
			//appDBContext.Add(vinylRecord4);

			//var category5 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.HipHop,
			//	Description = "Описание"
			//};
			//var vinylRecord5 = new VinylRecord
			//{
			//	Singer = "The Weeknd",
			//	Album = "Dawn FM",
			//	YearOfRelease = 2022,
			//	Description = "Описание",
			//	Image = "/img/5_0.jpg",
			//	Price = 6500,
			//	IsFavorite = false,
			//	Available = true,
			//	Category = category5,
			//};
			//appDBContext.Add(vinylRecord5);

			//var category6 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.Pop,
			//	Description = "Описание"
			//};
			//var vinylRecord6 = new VinylRecord
			//{
			//	Singer = "Lady Gaga",
			//	Album = "Born This Way",
			//	YearOfRelease = 2011,
			//	Description = "Описание",
			//	Image = "/img/6_0.jpg",
			//	Price = 6500,
			//	IsFavorite = false,
			//	Available = true,
			//	Category = category6,
			//};
			//appDBContext.Add(vinylRecord6);

			//var category7 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.Pop,
			//	Description = "Описание"
			//};
			//var vinylRecord7 = new VinylRecord
			//{
			//	Singer = "Lana Del Rey",
			//	Album = "Lust For Life",
			//	YearOfRelease = 2017,
			//	Description = "Описание",
			//	Image = "/img/7_0.jpg",
			//	Price = 6500,
			//	IsFavorite = false,
			//	Available = true,
			//	Category = category7,
			//};
			//appDBContext.Add(vinylRecord7);

			//var category8 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.Rock,
			//	Description = "Описание"
			//};
			//var vinylRecord8 = new VinylRecord
			//{
			//	Singer = "Bring Me The Horizon",
			//	Album = "Amo",
			//	YearOfRelease = 2019,
			//	Description = "Описание",
			//	Image = "/img/8_0.jpg",
			//	Price = 5500,
			//	IsFavorite = false,
			//	Available = true,
			//	Category = category8,
			//};
			//appDBContext.Add(vinylRecord8);

			//var category9 = new Category
			//{
			//	TypesOfMusic = CategoryTypesOfMusic.Rock,
			//	Description = "Описание"
			//};
			//var vinylRecord9 = new VinylRecord
			//{
			//	Singer = "Linkin Park",
			//	Album = "Hybrid Theory",
			//	YearOfRelease = 2000,
			//	Description = "Описание",
			//	Image = "/img/9_0.jpg",
			//	Price = 5500,
			//	IsFavorite = true,
			//	Available = true,
			//	Category = category9,
			//};
			//appDBContext.Add(vinylRecord9);

			//appDBContext.SaveChanges();
        }
    }    
}
