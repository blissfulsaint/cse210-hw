public class Reference
{
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse;

    public Reference()
    {
        _book = "";
        _chapter = 0;
        _firstVerse = 0;
        _lastVerse = 0;
    }

    public Reference(string book, int chapter, int firstVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = firstVerse;
    }

    public Reference(string book, int chapter, int firstVerse, int lastVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
    }

    public void Display()
    {
        Console.Write($"{_book} {_chapter}:{_firstVerse}");
        if (_firstVerse != _lastVerse)
        {
            Console.Write($"-{_lastVerse}");
        }
    }
}