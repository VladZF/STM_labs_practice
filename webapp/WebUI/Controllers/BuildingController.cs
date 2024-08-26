using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebUI.Requests;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingController(IBuildingService service) : ControllerBase
{
    [HttpPost("add-building")]
    public async Task<ActionResult<Building>> AddBuilding([FromBody] AddBuildingRequest request)
    {
        var building = await service.AddBuilding(request.Address, request.XPosition, request.YPosition);
        return Ok(building);
    }
    
    [HttpGet("get-all-buildings")]
    public async Task<ActionResult<List<Building>>> GetAllBuildings()
    {
        var buildings = await service.GetAllBuildings();
        return Ok(buildings);
    }
    
    [HttpGet("get-all-buildings-in-area")]
    public async Task<ActionResult<List<Building>>> GetAllBuildingsInArea([FromBody] GetAllBuildingsInAreaRequest request)
    {
        var buildings = await service.GetAllBuildingsInArea(
            request.LeftBottomX, 
            request.LeftBottomY,
            request.RightTopX,
            request.RightTopY);
        return Ok(buildings);
    }
    
    [HttpGet("get-building-by-id/{id:guid}")]
    public async Task<ActionResult<Building>> GetBuildingById(Guid id)
    {
        var building = await service.GetBuildingById(id);
        return Ok(building);
    }
    
    [HttpGet("get-building-by-address/{address}")]
    public async Task<ActionResult<Building>> GetBuildingByAddress(string address)
    {
        var building = await service.GetBuildingByAddress(address);
        return Ok(building);
    }
    
    [HttpDelete("delete-building")]
    public async Task<ActionResult> DeleteBuilding([FromBody] Guid id)
    {
        await service.DeleteBuilding(id);
        return Ok();
    }
}