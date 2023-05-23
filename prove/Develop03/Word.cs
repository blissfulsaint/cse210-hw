public class Word
{
    private string _word;
    private Boolean _isHidden;
    private string _hiddenWord;

    public Word(string word)
    {
        _word = word;

        _hiddenWord = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (Char.IsLetter(word[i]))
            {
                _hiddenWord += "_";
            }
            else
            {
                _hiddenWord += word[i];
            }
        }
    }

    public void HideWord()
    {
        _isHidden = true;
        Display();
    }

    public void ShowWord()
    {
        _isHidden = false;
        Display();
    }

    public void Display()
    {
        if (_isHidden == false)
        {
            Console.Write(_word);
        }
        else 
        {
            Console.Write(_hiddenWord);
        }
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
}