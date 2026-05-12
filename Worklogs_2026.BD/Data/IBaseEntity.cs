using Worklogs_2026.Shared.ENUM;

namespace Worklogs_2026.BD.Data
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        EnumRecordStatus RecordStatus { get; set; }
    }
}