using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs_2026.Shared.DTO
{
    public class WorkLogDTO
    {
        [Required(ErrorMessage = "Employee name is required.")]
        [MaxLength(50, ErrorMessage = "The employee name must not exceed {1} characters.")]
        public string EmployeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Activity is required.")]
        [MaxLength(30, ErrorMessage = "The Activity must not exceed {1} characters.")]
        public string Activity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date worked is required.")]
        public string DateWorked { get; set; } = string.Empty;

        [Required(ErrorMessage = "Time worked is required.")]
        public int TimeWorked { get; set; }
    }
}
