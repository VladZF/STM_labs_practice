namespace WebUI.Requests;

public record GetAllBuildingsInAreaRequest(double LeftBottomX, double LeftBottomY, double RightTopX, double RightTopY);