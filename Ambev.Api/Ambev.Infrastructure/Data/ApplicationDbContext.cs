using Ambev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public required DbSet<Employee> Employees { get; set; }
        public required DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("admins");

            modelBuilder.Entity<Employee>()
                .Property(e => e.DataAlteracao)
                .IsRequired(false)
                .HasDefaultValueSql("NULL");

            modelBuilder.Entity<Employee>()
                .Property(e => e.DataCriacao)
                .IsRequired(false)
                .HasDefaultValueSql("NULL");

            modelBuilder.Entity<Employee>()
                .Property(e => e.DataExclusao)
                .IsRequired(false)
                .HasDefaultValueSql("NULL");
        }
    }
}