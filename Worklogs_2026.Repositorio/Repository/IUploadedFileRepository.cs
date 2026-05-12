using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.Shared.DTO;

namespace Worklogs_2026.Repositorio.Repository
{
    public interface IUploadedFileRepository : IRepository<UploadedFile>
    {
        Task<List<UploadedFilesListDTO>> GetList();

        Task<bool> SyncFilesWithCloud();

        //Task<UploadedFile?> GetByFileName(string fileName);
    }
}