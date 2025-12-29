using Microsoft.EntityFrameworkCore;
using boxer_assessment.Domain.Entities;

namespace boxer_assessment.Data
{
    /// <summary>
    /// Database context for the application.
    /// </summary>
    public class EmployeeDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new database context.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Employees table.
        /// </summary>
        public DbSet<Employee> Employees { get; set; } = null!;

        /// <summary>
        /// Job titles table.
        /// </summary>
        public DbSet<JobTitle> JobTitles { get; set; } = null!;

        /// <summary>
        /// Configures entity mappings and constraints.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.ToTable("JobTitle");

                entity.HasKey(e => e.JobTitleId);

                entity.Property(e => e.TitleName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(e => e.TitleName)
                      .IsUnique();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasIndex(e => e.Email)
                      .IsUnique();

                entity.Property(e => e.Salary)
                      .IsRequired();

                entity.Property(e => e.IsActive)
                      .IsRequired();

                entity.HasOne(e => e.JobTitle)
                      .WithMany()
                      .HasForeignKey(e => e.JobTitleId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.ToTable(table =>
                {
                    table.HasCheckConstraint(
                        "CK_Employee_Salary",
                        "Salary >= 0"
                    );
                });
            });
        }
    }
}
