
using Worklogs_2026.BD.Data;

namespace Worklogs_2026.Repositorio.Repository
{
    public interface IRepository<E> where E : class, IBaseEntity
    {
        Task<bool> Delete(int id);
        Task<bool> Existe(int id);
        Task<E?> GetById(int id);
        Task<List<E>> GetFull();
        Task<int> Post(E entidad);
        Task<bool> Put(int id, E entidad);
    }
}