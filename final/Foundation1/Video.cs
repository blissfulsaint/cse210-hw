public class Video
{
    string _title;
    string _author;
    int _length;
    List<Comment> _comments = new List<Comment>();

    public Video()
    {
        _title = "";
        _author = "";
        _length = 0;
    }

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public Video(string title, string author, int length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public void SetAuthor(string author)
    {
        _author = author;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    private void DisplayComments()
    {
        foreach (Comment comment in _comments)
        {
            comment.Display();
        }
    }

    private int GetNumComments()
    {
        return _comments.Count();
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {_title} \nAuthor: {_author} \nLength: {_length} \nComments: {GetNumComments()}");
        DisplayComments();
    }
}