namespace DelegatesAndEvents.Task4Classes;

public class Post
{
    public event Action<string> Notify; 
    
    private string _text;
    private string _title;
    
    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Title must be not empty");
            }
            var oldVersion = _title;
            _title = value;
            Notify?.Invoke($"EDITED TITLE IN POST FROM '{oldVersion}' TO '{_title}'");
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
            var oldVersion = _text;
            _text = value;
            Notify?.Invoke($"EDITED TEXT IN POST WITH TITLE '{_title}':\nOLD:\n{oldVersion}\nNEW:\n{_text}");
        }
    }

    public void Subscribe(Action<string> handler) => Notify += handler;
    
    public Post(string title, string text)
    {
        Title = title;
        Text = text;
    }
}