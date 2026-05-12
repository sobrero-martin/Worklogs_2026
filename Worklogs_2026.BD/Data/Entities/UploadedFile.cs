using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs_2026.BD.Data.Entities
{
    [Index(nameof(FileName), Name = "UploadedFiles_FileName_UQ", IsUnique = true)]
    public class UploadedFile : BaseEntity
    {
        [Required(ErrorMessage = "File name is required.")]
        [MaxLength(50, ErrorMessage = "The file name must not exceed {1} characters.")]
        public required string FileName { get; set; }

        [Required(ErrorMessage = "Upload date is required.")]
        public  DateTime UploadDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "File path is required.")]
        [MaxLength(255, ErrorMessage = "The file path must not exceed {1} characters.")]
        public required string FilePath { get; set; }
    }
}
