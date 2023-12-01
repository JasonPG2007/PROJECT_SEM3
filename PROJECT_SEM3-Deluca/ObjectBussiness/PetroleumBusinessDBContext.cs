using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ObjectBussiness
{
    public class PetroleumBusinessDBContext : DbContext
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ResultCandidate> ResultCandidates { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Decentralization> Decentralizations { get; set; }
        public DbSet<ExamRegister> ExamRegister { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Elect> Elects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<History> Histories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configurationRoot = builder.Build();
            optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("MyConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add data table Role
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Admin" },
                new Role { RoleID = 2, RoleName = "Candidate" });

            //Add data table Elect
            modelBuilder.Entity<Elect>().HasData(
                new Elect { ElectID = 1, Status = true },
                new Elect { ElectID = 2, Status = false });
        }
    }
}