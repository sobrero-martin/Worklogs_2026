using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.BD.Data;

namespace Worklogs_2026.BD.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
            // Example: modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
