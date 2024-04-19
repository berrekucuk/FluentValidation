using Microsoft.EntityFrameworkCore;

namespace _02.FluentValidation.Models.ORM
{
    public class AkademiIstanbulContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= LAPTOP-2K18C6FK\SQLEXPRESS; Database=AkademiIstanbulDb; Trusted_Connection=True; TrustServerCertificate=True");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set;}
    }
}
