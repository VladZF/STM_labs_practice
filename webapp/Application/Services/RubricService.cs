using Domain.Entities;
using Domain.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class RubricService(ApplicationDbContext db) : IRubricService
{
    public async Task<Rubric> CreateRubric(string name)
    {
        var rubric = new Rubric(name);
        await db.Rubrics.AddAsync(rubric);
        await db.SaveChangesAsync();
        return rubric;
    }

    public async Task AddSubRubric(Guid rubricId, Guid subRubricId)
    {
        var mainRubric = await db.Rubrics.FirstAsync(rubric => rubric.Id == rubricId);
        var subRubric = await db.Rubrics.FirstAsync(rubric => rubric.Id == subRubricId);
        mainRubric.AddSubRubric(subRubric);
    }

    public async Task<Rubric> GetRubric(Guid id)
    {
        return await db.Rubrics.FirstAsync(rubric => rubric.Id == id);
    }
}