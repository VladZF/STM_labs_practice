using Domain.Entities;

namespace Domain.Repositories;

public interface ICompanyService
{
    public Task<IEnumerable<Company>> GetAllCompaniesInArea(double leftBottomX, double leftBottomY, double rightTopX, double rightTopY);
    public Task<IEnumerable<Company>> GetAllCompaniesInBuilding(Guid buildingId);
    public Task<IEnumerable<Company>> GetAllCompaniesByRubric(Rubric rubric);
    public Task<Company> GetCompanyById(Guid id);
    public Task<Company> AddCompany(string name, Building building);
    public Task DeleteCompany(Guid id);
}