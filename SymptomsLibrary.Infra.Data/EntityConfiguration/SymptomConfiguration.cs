using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SymptomsLibrary.Domain.Entities;

namespace SymptomsLibrary.Infra.Data.EntityConfiguration;

internal class SymptomConfiguration : IEntityTypeConfiguration<Symptom>
{
    public void Configure(EntityTypeBuilder<Symptom> builder)
    {
        builder.HasKey(nameof(Symptom.Id));
        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
