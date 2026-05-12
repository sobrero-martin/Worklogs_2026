using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs_2026.BD.Data;
using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.Shared.DTO;

namespace Worklogs_2026.Repositorio.Repository
{
    public class UserRepository : Repository<UserTest>, IRepository<UserTest>, IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> Login(LoginDTO login)
        {
            var user = await context.UserTests.FirstOrDefaultAsync(x => x.Email == login.Email && x.PasswordHash == login.Password);
            if (user == null) return 0;
            return user.Id;
        }

        /*
        public async Task<User?> GetByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        */
    }
}
