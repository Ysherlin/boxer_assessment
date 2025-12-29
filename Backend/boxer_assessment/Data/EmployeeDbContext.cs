using Microsoft.EntityFrameworkCore;
using boxer_assessment.Domain.Entities;

namespace boxer_assessment.Data
{
    /// <summary>
    /// Entity Framework database context.
    /// </summary>
    public class EmployeeDbContext : DbContext
    {
        /// <summary>
        /// Creates a new database context instance.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Employees table.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Job titles table.
        /// </summary>
        public DbSet<JobTitle> JobTitles { get; set; }

        /// <summary>
        /// Configures the entity model.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
