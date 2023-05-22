public class Word
{
    private string _word;
    private Boolean _isHidden;
    private string _hiddenWord;

    public void HideWord()
    {
        _isHidden = true;
    }

    public void ShowWord()
    {
        _isHidden = false;
    }

    public void Display()
    {
        Console.Write(_word);
    }
}