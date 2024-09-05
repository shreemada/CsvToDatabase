using Microsoft.EntityFrameworkCore;

namespace CsvToDatabase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=DBA;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
