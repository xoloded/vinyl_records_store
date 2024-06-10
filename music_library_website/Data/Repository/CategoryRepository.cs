using music_library_website.Data.Interfaces;
using music_library_website.Data.Models;

namespace music_library_website.Data.Repository
{
	public class CategoryRepository : IAllVinylRecordsCategory
	{
		private readonly AppDBContext appDBContent;

		public CategoryRepository(AppDBContext appDBContent)
		{
			this.appDBContent = appDBContent;
		}
		public IEnumerable<Category> AllCategories => appDBContent.Categories;
	}
}
