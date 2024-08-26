using Domain.Entities;

namespace Domain.Repositories;

public interface IBuildingService
{
    public Task<List<Building>> GetAllBuildings();
    public Task<List<Building>> GetAllBuildingsInArea(double leftBottomX, double leftBottomY, double rightTopX, double rightTopY);
    public Task<Building> GetBuildingById(Guid id);
    public Task<Building> GetBuildingByAddress(string address);
    public Task<Building> AddBuilding(string address, double xPosition, double yPosition);
    public Task DeleteBuilding(Guid id);
}