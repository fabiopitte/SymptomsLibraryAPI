using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SymptomsLibrary.Domain.Entities;

namespace SymptomsLibrary.Infra.Data.EntityConfiguration;

internal class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.HasKey(nameof(Disease.Id));
        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
