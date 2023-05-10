public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void SortByDateDesc()
    {
        _entries.Sort((a, b) => a.GetDate().CompareTo(b.GetDate()));
    }

    public void SortByDateAsc()
    {
        _entries.Sort((a, b) => b.GetDate().CompareTo(a.GetDate()));
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
            Console.WriteLine();
        }
    }

    public void DisplayFilteredJournal(List<Entry> entries, List<int> indexes)
    {
        for (int i = 0; i < entries.Count(); i++)
        {
            Console.WriteLine($"Index: {indexes[i]}");
            entries[i].DisplayEntry();
            Console.WriteLine();
        }
    }

    public void LookupByPrompt(string prompt)
    {
        List<Entry> entries = new List<Entry>();
        List<int> indexes = new List<int>();

        for (int i = 0; i < _entries.Count(); i++)
        {
            if (_entries[i].GetPrompt() == prompt)
            {
                entries.Add(_entries[i]);
                indexes.Add(i);
            }
        }
        DisplayFilteredJournal(entries, indexes);
    }

    public void SearchByKeyword(string keyword)
    {
        List<Entry> entries = new List<Entry>();
        List<int> indexes = new List<int>();

        for (int i = 0; i < _entries.Count(); i++)
        {
            if (_entries[i].GetEntry().Contains(keyword) == true)
            {
                entries.Add(_entries[i]);
                indexes.Add(i);
            }
        }
        DisplayFilteredJournal(entries, indexes);
    }

    public void AddEntry()
    {
        
    }
}