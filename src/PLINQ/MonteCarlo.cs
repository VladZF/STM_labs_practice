using BenchmarkDotNet.Attributes;

namespace PLINQ;

public class MonteCarlo
{
    private const int CircleRadius = 1;
    private const int PointsCount = 1000000;

    private readonly List<(double x, double y)> _pointsList = [];
    private static bool InCircle(double x, double y) => x * x + y * y <= CircleRadius * CircleRadius;
    
    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();
        for (var i = 0; i < PointsCount; i++)
        {
            _pointsList.Add((random.NextDouble(), random.NextDouble()));
        }
    }
    
    [Benchmark]
    public double GetPi()
    {
        var pointsInCircle = _pointsList
            .Count(point => InCircle(point.x, point.y));
        return 4 * ((double)pointsInCircle / PointsCount);
    }
    
    [Benchmark]
    public double GetPiParallel()
    {
        var pointsInCircle = _pointsList
            .AsParallel()
            .Count(point => InCircle(point.x, point.y));
        return 4 * ((double)pointsInCircle / PointsCount);
    }
}