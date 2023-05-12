public class Entry
{
    private DateTime _date;
    private string _dateString;
    private string _response;
    private string _prompt = "";
    private string _promptType = "";

    public void LogEntry(string entry, DateTime date, string prompt = "", string promptType = "")
    {
        _response = entry;
        _date = date;
        _dateString = _date.ToShortDateString();

        if (prompt != "")
        {
            _prompt = prompt;
            _promptType = promptType;
        }
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

    public string GetPromptType()
    {
        return _promptType;
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