﻿using music_library_website.Data.Models;

namespace music_library_website.Data.Interfaces
{
    public interface IAllVinylRecordsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
