namespace DelegatesAndEvents.Task4Classes;

public class Poster(string name)
{
    public event Action<string, string>? OnPostAdded;

    public event Action<string, string>? OnPostDeleted; 
    public string Name { get; init; } = name;
    private readonly HashSet<Post> _posts = [];

    public IEnumerable<Post> Posts => _posts;
    
    public void AddPost(string title, string text)
    {
        if (_posts.Any(x => x.Title == title))
        {
            throw new ArgumentException($"{Name} has post with this name");
        }
        _posts.Add(new Post(title, text));
        OnPostAdded?.Invoke(Name, title);
    }
    
    public Post GetPost(string title)
    {
        var post = _posts.FirstOrDefault(x => x.Title == title);
        if (post == null)
        {
            throw new ArgumentException($"'{Name}' has no post '{title}'");
        }

        return post;
    }
    
    public void DeletePost(string title)
    {
        var post = _posts.FirstOrDefault(x => x.Title == title);
        if (post == null)
        {
            throw new ArgumentException($"'{Name}' has no post '{title}'");
        }
        _posts.Remove(post);
        OnPostDeleted?.Invoke(Name, title);
    }
}