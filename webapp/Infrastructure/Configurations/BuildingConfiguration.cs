using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(building => building.Id);
        builder
            .HasMany(building => building.Companies)
            .WithOne(company => company.Building)
            .HasForeignKey(company => company.BuildingId);
    }
}