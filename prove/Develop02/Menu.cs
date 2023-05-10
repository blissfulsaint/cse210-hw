public class Menu
{
    Journal _journal;
    File _file;

    public Menu(File file)
    {
        _file = file;
    }

    public void LoadJournal()
    {
        string[] lines = _file.LoadFile();

        if (lines[0] == "--- Journal File ---")
        {

        }
    }

    public void SaveJournal()
    {
        List<string> lines;
        
    }
}