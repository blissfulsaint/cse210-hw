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
    }

    public void ShowWord()
    {
        _isHidden = IsSpecialChar();
    }

    public void Display()
    {
        if (_word.Contains("<"))
        {
            Console.Write($"\n{_word.Substring(1)}");
        }
        else if (_isHidden == false)
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

    public bool IsSpecialChar()
    {
        return (int.TryParse(_word, out int number) || _word == "-" || _word.Contains("<"));
    }
}