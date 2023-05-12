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
        for (int i = 0; i < _entries.Count(); i++)
        {
            Console.WriteLine($"Index: {i}");
            _entries[i].DisplayEntry();
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

    public void SearchByPrompt(string prompt)
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

    public void InsertNewEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void RemoveEntry(int index)
    {
        _entries.Remove(_entries[index]);
    }

    public List<Entry> GetEntries()
    {
        return _entries;
    }

    public void ClearEntries()
    {
        _entries.Clear();
    }
}