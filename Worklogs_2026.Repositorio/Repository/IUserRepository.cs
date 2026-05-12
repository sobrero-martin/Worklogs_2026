using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.Shared.DTO;

namespace Worklogs_2026.Repositorio.Repository
{
    public interface IUserRepository : IRepository<UserTest>
    {
        Task<int> Login(LoginDTO login);

        //Task<User?> GetByEmail(string email);
    }
}