using company_app.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace company_app.Data
{
   public class CompanyContext : DbContext
   {
      // create constructor
      public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
      {

      }

      // override
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         base.OnConfiguring(optionsBuilder);
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
      }

      // list table
      public virtual DbSet<Employee> Employees { get; set; }
   }
}
