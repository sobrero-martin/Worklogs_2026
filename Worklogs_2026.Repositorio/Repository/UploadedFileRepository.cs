using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs_2026.BD.Data;
using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.Repositorio.Repository.Supabase;
using Worklogs_2026.Shared.DTO;


namespace Worklogs_2026.Repositorio.Repository
{
    public class UploadedFileRepository : Repository<UploadedFile>, IRepository<UploadedFile>, IUploadedFileRepository
    {

        private readonly AppDbContext context;
        private readonly IWorkLogRepository workLogRepository;

        public UploadedFileRepository(AppDbContext context, IWorkLogRepository workLogRepository) : base(context)
        {
            this.context = context;
            this.workLogRepository = workLogRepository;
        }


        public async Task<List<UploadedFilesListDTO>> GetList()
        {
            return await context.UploadedFiles
                .Select(x => new UploadedFilesListDTO
                {
                    FileId = x.Id,
                    FileName = x.FileName,
                    UploadDate = x.UploadDate.ToString("yyyy-MM-dd"),
                })
                .ToListAsync();
        }

        public async Task<bool> SyncFilesWithCloud()
        {
            var supabase = new SupabaseClient().GetClient();
            await supabase.InitializeAsync();

            var bucket = supabase.Storage.From("worklogs");
            var filesInDb = await GetFull();

            var cloudFiles = await bucket.List();
            

            if (cloudFiles == null || cloudFiles.Count == 0)
            {
                return false;
            }
            cloudFiles = cloudFiles.Where(f => f.Name != ".emptyFolderPlaceholder").ToList();
            var fileNamesInCloud = cloudFiles.Select(f => f.Name).ToList();
            var fileNamesInDb = filesInDb.Select(f => f.FileName).ToList();

            foreach (var file in filesInDb)
            {
                if(!fileNamesInCloud.Contains(file.FileName))
                {
                    await Delete(file.Id);
                }
            }

            foreach (var cloudFile in cloudFiles) 
            {
                if (cloudFile.Name != null && !fileNamesInDb.Contains(cloudFile.Name))
                {
                    var uploadedFile = new UploadedFile
                    {
                        FileName = cloudFile.Name,
                        UploadDate = cloudFile.CreatedAt ?? DateTime.Now,
                        FilePath = bucket.GetPublicUrl(cloudFile.Name),
                    };

                    await Post(uploadedFile);
                    await workLogRepository.GetWorklogsExcel(uploadedFile.Id, uploadedFile.FilePath);
                }
            }

            return true;
        }

        /*
        public async Task<UploadedFile?> GetByFileName(string fileName)
        {
            return await context.UploadedFiles.FirstOrDefaultAsync(x => x.FileName == fileName);
        }
        */
    }
}
