using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(company =>  company.Id);
        builder
            .HasOne(company => company.Building)
            .WithMany(building => building.Companies)
            .HasForeignKey(company => company.BuildingId);
        builder
            .HasMany(company => company.Rubrics)
            .WithMany(rubric => rubric.Companies);
    }
}