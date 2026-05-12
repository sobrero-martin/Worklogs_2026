using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.Shared.DTO;

namespace Worklogs_2026.Repositorio.Repository
{
    public interface IWorkLogRepository : IRepository<WorkLog>
    {
        Task GetWorklogsExcel(int uploadedFileID, string filePath);

        Task<List<WorkLogDTO>> GetList(int uploadedFileID);
    }
}
