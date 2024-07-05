namespace BaseAlgorithms;

public class City(HashSet<string> toysList)
{
    private readonly HashSet<KinderGarden> _kinderGardens = [];
    public void AddGarden(KinderGarden garden)
    {
        if (_kinderGardens.FirstOrDefault(x => x.Number == garden.Number) != null)
        {
            throw new ArgumentException($"KinderGarden №{garden.Number} already exists");
        }
        _kinderGardens.Add(garden);
    }
    
    public HashSet<(string name, string status)> GetStatisticsAboutToys()
    {
        HashSet<(string name, string status)> statuses = [];
        foreach (var toy in toysList)
        {
            var counter = _kinderGardens.Count(garden => garden.Contains(toy));
            if (counter == _kinderGardens.Count)
            {
                statuses.Add((toy, "found in all gardens"));
            }
            else if (counter == 0)
            {
                statuses.Add((toy, "not found in any garden"));
            }
            else
            {
                statuses.Add((toy, $"found in {counter} garden(s)"));
            }
        }

        return statuses;
    }
}