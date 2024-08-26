using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RubricConfiguration : IEntityTypeConfiguration<Rubric>
{
    
    public void Configure(EntityTypeBuilder<Rubric> builder)
    {
        builder.HasKey(rubric => rubric.Id);
        builder
            .HasOne(rubric => rubric.MainRubric)
            .WithMany(rubric => rubric.SubRubrics)
            .HasForeignKey(rubric => rubric.MainRubricId);
        builder
            .HasMany(rubric => rubric.Companies)
            .WithMany(company => company.Rubrics);
    }
}