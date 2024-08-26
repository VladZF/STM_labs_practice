using Domain.Entities;
using Domain.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class BuildingService(ApplicationDbContext db) : IBuildingService
{
    public async Task<List<Building>> GetAllBuildings()
        => await db.Buildings.ToListAsync();

    public async Task<List<Building>> GetAllBuildingsInArea(double leftBottomX, double leftBottomY, double rightTopX, double rightTopY)
        => await db.Buildings
            .Where(building => 
                    leftBottomX <= building.XPosition
                    && building.XPosition <= rightTopX
                    && leftBottomY <= building.YPosition
                    && building.YPosition <= rightTopY)
            .ToListAsync();

    public async Task<Building> GetBuildingById(Guid id)
        => await db.Buildings.FirstAsync(building => building.Id == id);

    public async Task<Building> GetBuildingByAddress(string address)
        => await db.Buildings.FirstAsync(building => building.Address == address);

    public async Task<Building> AddBuilding(string address, double xPosition, double yPosition)
    {
        var building = new Building(address, xPosition, yPosition);
        await db.Buildings.AddAsync(building);
        await db.SaveChangesAsync();
        return building;
    }

    public async Task DeleteBuilding(Guid id)
    {
        var buildingToRemove = await db.Buildings.FirstAsync(building => building.Id == id);
        db.Buildings.Remove(buildingToRemove);
    }
}