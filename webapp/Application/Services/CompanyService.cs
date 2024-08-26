using Domain.Entities;
using Domain.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class CompanyService(ApplicationDbContext db) : ICompanyService
{
    public async Task<IEnumerable<Company>> GetAllCompaniesInArea(double leftBottomX, double leftBottomY, double rightTopX, double rightTopY)
        => await db.Companies.Where(
            company => leftBottomX <= company.Building.XPosition
                       && company.Building.XPosition <= rightTopX
                       && leftBottomY <= company.Building.YPosition
                       && company.Building.YPosition <= rightTopY).ToListAsync();


    public async Task<IEnumerable<Company>> GetAllCompaniesInBuilding(Guid buildingId)
        => await db.Companies.Where(company => company.BuildingId == buildingId).ToListAsync();

    public async Task<IEnumerable<Company>> GetAllCompaniesByRubric(Rubric rubric)
    {
        var companies = await db.Companies
            .Where(company => company.Rubrics.Contains(rubric)).ToListAsync();
        foreach (var subRubric in rubric.SubRubrics)
        {
            companies.AddRange(await GetAllCompaniesByRubric(subRubric));
        }
        return companies;
    }

    public async Task<Company> GetCompanyById(Guid id)
        => await db.Companies.FirstAsync(company => company.Id == id);

    public async Task<Company> AddCompany(string name, Building building)
    {
        var company = new Company(name, building);
        await db.Companies.AddAsync(company);
        await db.SaveChangesAsync();
        return company;
    }

    public async Task DeleteCompany(Guid id)
    {
        var companyToDelete = await db.Companies.FirstAsync(company => company.Id == id);
        db.Companies.Remove(companyToDelete);
    }
}