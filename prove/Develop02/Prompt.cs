public class Prompt
{

    List<string> _promptList = new List<string>();
    string _promptType;
    string _promptFileIndicator = "Prompt Type: ";

    public Prompt(string[] lines)
    {
        foreach (string line in lines)
        {
            if (line.Contains(_promptFileIndicator))
            {
                _promptType = line.Replace(_promptFileIndicator, "");
            }
            else
            {
                _promptList.Add(line);
            }
        }
    }

    public void AddPrompt(string prompt)
    {
        _promptList.Add(prompt);
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _promptList[rand.Next(0, _promptList.Count())];
    }

    public void DisplayPrompts()
    {
        foreach (string prompt in _promptList)
        {
            Console.WriteLine(prompt);
        }
    }

    public void SetType(string type)
    {
        _promptType = type;
    }

    public new string GetType()
    {
        return _promptType;
    }
}