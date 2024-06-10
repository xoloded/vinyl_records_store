using music_library_website.Data.Models;

namespace music_library_website.Data.Interfaces
{
    public interface IAllVinylRecords
    {
        IEnumerable<VinylRecord> VinylRecords { get; }
        IEnumerable<VinylRecord> GetFavoriteVinylRecords { get; }
        VinylRecord GetObjectVinylRecord(int vinylRecordId);
        void AddVinylRecordsInDataBase();
    }
}
