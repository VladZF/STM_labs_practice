namespace BaseAlgorithms;

public class City(HashSet<string> toysList)
{
    private readonly HashSet<KinderGarden> _kinderGardens = [];
    public List<string> GetToysFoundInAllGardens =>
        toysList.Where(toy => _kinderGardens.All(garden => garden.Contains(toy))).ToList();

    public List<string> GetToysNotFoundInAnyGarden =>
        toysList.Where(toy => !_kinderGardens.Any(garden => garden.Contains(toy))).ToList();
    public void AddGarden(KinderGarden garden)
    {
        if (_kinderGardens.FirstOrDefault(x => x.Number == garden.Number) != null)
        {
            throw new ArgumentException($"KinderGarden №{garden.Number} already exists");
        }
        _kinderGardens.Add(garden);
    }
}