using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs_2026.Shared.ENUM;

namespace Worklogs_2026.BD.Data
{

    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public EnumRecordStatus RecordStatus { get; set; } = EnumRecordStatus.Draft;
    }
}
