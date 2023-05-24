public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _ref = new Reference();
    private int _chance = 3;
    private int _hiddenWords;

    public Scripture(string scripture, Reference reference)
    {
        ConvertStringToList(scripture);
        _ref = reference;
    }

    public void Display()
    {
        Console.Clear();

        _ref.Display();

        Console.WriteLine("");

        foreach (Word word in _words)
        {
            word.Display();
            Console.Write(" ");
        }

        Console.WriteLine("\n");

        if (IsCompletelyHidden() == true)
        {
            Environment.Exit(0);
        }

        Console.Write("Press the enter key to continue or type quit to exit the program.");
        string response = Console.ReadLine();

        if (response.ToUpper() == "QUIT")
        {
            Environment.Exit(0);
        }
        else
        {
            HideWords();
        }
    }

    public void ConvertStringToList(string scripture)
    {
        string[] words = scripture.Split(" ");

        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    public void HideWords()
    {
        if (IsCompletelyHidden())
        {
            Environment.Exit(0);
        }

        int startHidden = _hiddenWords;

        foreach (Word word in _words)
        {
            Random rand = new Random();
            bool toHide = rand.Next(0, _chance) == 0;
            if (_hiddenWords == _words.Count() - 1 || word.IsHidden() == true || toHide)
            {
                if (!word.IsHidden())
                {
                    _hiddenWords++;
                }
                word.HideWord();
            }
            else
            {
                word.ShowWord();
            }
        }

        if (startHidden == _hiddenWords)
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    word.HideWord();
                    _hiddenWords++;
                    break;
                }
            }
        }

        Display();
    }

    public bool IsCompletelyHidden()
    {
        _hiddenWords = 0;
        bool isHidden = true;

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                isHidden = false;
            }
            else
            {
                _hiddenWords++;
            }
        }
        return isHidden;
    }

    public void ShowAllWords()
    {
        foreach (Word word in _words)
        {
            word.ShowWord();
        }
    }
}