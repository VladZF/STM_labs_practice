using System.Text.RegularExpressions;
using DelegatesAndEvents.Task5Classes.StringLoaderExceptions;

namespace DelegatesAndEvents.Task5Classes;

public partial class LimitedStringLoader
{
    private readonly List<string> _loadedStrings = [];
    private readonly string _prohibited = null!;
    private readonly string _erroneous = null!;
    private int _proLimit;
    private int _prohibitionCount;

    public IEnumerable<string> LoadedStrings
    {
        get
        {
            if (_loadedStrings.Count == 0)
            {
                throw new DataNotLoadedException();
            }

            return _loadedStrings;
        }
    }
    
    public string Prohibited { 
        get => _prohibited;
        init
        {
            ArgumentNullException.ThrowIfNull(value);
            _prohibited = value.ToUpper();
        }
    }
    
    public int ProhibitionCount
    {
        get
        {
            if (_loadedStrings.Count == 0)
            {
                throw new DataNotLoadedException();
            }
            return _prohibitionCount;
        }
        private set => _prohibitionCount = value;
    }
    public string Erroneous
    {
        get => _erroneous;
        init
        {
            ArgumentNullException.ThrowIfNull(value);
            _erroneous = value.ToUpper();
        }
    }
    public int ProLimit
    {
        get => _proLimit;
        init
        {
            if (value < 0)
            {
                throw new ArgumentException("Prohibition limit must be non-negative");
            }
            _proLimit = value;
        }
    }
    
    public LimitedStringLoader(string prohibited, string erroneous, int proLimit)
    {
        var intersected = prohibited.ToUpper().Intersect(erroneous.ToUpper()).ToArray();
        if (intersected.Length != 0)
        {
            throw new InconsistentLimitsException(intersected);
        }
        Prohibited = prohibited;
        Erroneous = erroneous;
        ProLimit = proLimit;
    }
    
    public void Load(string fileName)
    {
        if (!File.Exists(fileName))
        {
            _loadedStrings.Clear();
            throw new FileNotFoundException($"File {fileName} not found");
        }
        using var reader = new StreamReader(fileName);
        var prohibitionCounter = 0;
        var row = 0;
        while (!reader.EndOfStream)
        {
            row++;
            var line = reader.ReadLine();
            if (string.IsNullOrEmpty(line))
                continue;
            if (!LoaderPattern().IsMatch(line))
            {
                _loadedStrings.Clear();
                throw new IncorrectStringException(row);
            }
            if (Erroneous.Contains(line[0]))
            {
                _loadedStrings.Clear();
                throw new WrongStartingSymbolException(row, line[0]);
            }
            if (Prohibited.Contains(line[0]))
            {
                prohibitionCounter++;
                if (prohibitionCounter > ProLimit)
                {
                    _loadedStrings.Clear();
                    throw new TooManyProhibitedLinesException(ProLimit);
                }
                continue;
            }
            _loadedStrings.Add(line);
        }
        ProhibitionCount = prohibitionCounter;
    }

    [GeneratedRegex(@"^[A-Z](\s-?\d+(\.\d+)?)+$")]
    private static partial Regex LoaderPattern();
}