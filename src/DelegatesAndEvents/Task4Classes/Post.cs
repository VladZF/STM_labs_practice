namespace DelegatesAndEvents.Task4Classes;

public class Post
{
    private string _text = null!;
    private string _title = null!;
    
    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Title must be not empty");
            }
            _title = value;
        }
    }
    public string Text
    {
        get => _text;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Text must be not empty");
            }
            _text = value;
        }
    }
    
    public Post(string title, string text)
    {
        Title = title;
        Text = text;
    }
}