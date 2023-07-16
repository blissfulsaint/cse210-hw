public class Comment
{
    string _name;
    string _comment;

    public Comment()
    {
        _name = "";
        _comment = "";
    }

    public Comment(string name, string comment)
    {
        _name = name;
        _comment = comment;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetComment(string comment)
    {
        _comment = comment;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetComment()
    {
        return _comment;
    }

    public void Display()
    {
        Console.WriteLine($"@{_name}: \"{_comment}\"");
    }
}