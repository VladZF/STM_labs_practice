namespace BaseAlgorithms;

public class KinderGarden(int number, HashSet<string> toys) : IEquatable<KinderGarden>
{
    public int Number { get; } = number;

    public IEnumerable<string> Toys => toys;
    public bool Contains(string toyName) => toys.Contains(toyName);

    public bool Equals(KinderGarden? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Number == other.Number;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((KinderGarden)obj);
    }

    public override int GetHashCode()
    {
        return Number;
    }
}