public class Prompt
{

    List<string> _promptList = new List<string>();
    string _promptType;

    public Prompt(string type = "normal")
    {
        _promptType = type;
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