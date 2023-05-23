public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _ref = new Reference();
    private int _chance = 3;
    private int _hiddenWords;

    public void Display()
    {
        _ref.Display();

        foreach (Word word in _words)
        {
            word.Display();
        }
    }

    public void ConvertStringToList(string scripture)
    {
        string[] words = scripture.Split("_");

        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    public void HideWords()
    {
        if (IsCompletelyHidden() == true)
        {
            return;
        }

        foreach (Word word in _words)
        {
            Random rand = new Random();
            bool toHide = rand.Next(0, _chance) == 0;
            if (_hiddenWords == _words.Count() - 1 || word.IsHidden() == true || toHide)
            {
                word.HideWord();
            }
            else
            {
                word.ShowWord();
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        _hiddenWords = 0;
        bool isHidden = true;

        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
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
}