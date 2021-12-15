using Microsoft.EntityFrameworkCore;
using SymptomsLibrary.Infra.Data.EntityConfiguration;
using SymptomsLibrary.Domain.Entities;

namespace SymptomsLibrary.Infra.Data.Context;
public class SymptomsLibraryDbContext : DbContext
{
    public SymptomsLibraryDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Disease> Diseases { get; set; }
    public DbSet<Symptom> Symptoms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DiseaseConfiguration());
        modelBuilder.ApplyConfiguration(new SymptomConfiguration());

        modelBuilder.Entity<Disease>().HasMany(e => e.Symptoms).WithOne(e => e.Disease).IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
