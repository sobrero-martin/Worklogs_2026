using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs_2026.Shared.DTO
{
    public class UploadedFilesListDTO
    {
        public int FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string UploadDate { get; set; } = string.Empty;

    }
}
