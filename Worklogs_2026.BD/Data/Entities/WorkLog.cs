using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs_2026.BD.Data.Entities
{
    public class WorkLog : BaseEntity
    {
        public int UploadedFileID { get; set; }
        public UploadedFile? UploadedFile { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [MaxLength(50, ErrorMessage = "Employee name cannot exceed 50 characters.")]
        public required string EmployeeName { get; set; }

        [Required(ErrorMessage = "Activity is required.")]
        [MaxLength(30, ErrorMessage = "Activity cannot exceed 30 characters.")]
        public required string Activity { get; set; }

        [Required(ErrorMessage = "Date worked is required.")]
        public required string DateWorked { get; set; }

        [Required(ErrorMessage = "Time worked is required.")]
        public required int TimeWorked { get; set; } // in seconds

    }
}
