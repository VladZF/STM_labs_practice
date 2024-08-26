using Domain.Entities;

namespace Domain.Repositories;

public interface IRubricService
{
    public Task<Rubric> CreateRubric(string name);
    public Task AddSubRubric(Guid rubricId, Guid subRubricId);
    public Task<Rubric> GetRubric(Guid id);
}