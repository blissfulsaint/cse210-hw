public class Entry
{
    private DateTime _date;
    private string _dateString;
    private string _response;
    private string _prompt;
    private string _promptType;

    public void LogEntry(string entry)
    {
        _response = entry;
        _date = DateTime.Now;
        _dateString = _date.ToShortDateString();
    }

    public string GetEntry()
    {
        return _response;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public string GetDateString()
    {
        return _dateString;
    }

    public void LoadPrompt(Prompt prompt)
    {
        _prompt = prompt.GetRandomPrompt();
        _promptType = prompt.GetType();
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public void DisplayResponse()
    {
        Console.WriteLine(_response);
    }

    public void DisplayDate()
    {
        Console.WriteLine(_dateString);
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(_prompt);
    }

    public void DisplayPromptType()
    {
        Console.WriteLine(_promptType);
    }

    public void DisplayEntry()
    {
        DisplayPrompt();
        DisplayDate();
        DisplayResponse();
    }
}