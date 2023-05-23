public class Reference
{
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse;

    public void Display()
    {
        Console.Write($"{_book} {_chapter}:{_firstVerse}");
        if (_firstVerse != _lastVerse)
        {
            Console.Write($"-{_lastVerse}");
        }
    }
}