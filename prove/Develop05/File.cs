public class File
{
    string _currentDir = "";
    string _fileName = "";

    public string[] LoadFile()
    {
        try
        {
            if (_fileName != "")
            {
                string[] lines = System.IO.File.ReadAllLines(_fileName);
                return lines;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public void SaveFile(List<string> lines)
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            foreach (string line in lines)
            {
                outputFile.WriteLine(line);
            }
        }
    }

    public void SetCurrentDir(string directory)
    {
        _currentDir = directory;
    }

    public void SetFileName(string fileName)
    {
        _fileName = fileName;
    }

    public void DisplayCurrentDir()
    {
        Console.WriteLine($"This is the current directory: {_currentDir}");
    }

    public void DisplayFileName()
    {
        Console.WriteLine($"This is the current file name: {_fileName}");
    }

    public string GetFileName()
    {
        return _fileName;
    }

    public string GetDir()
    {
        return _currentDir;
    }
}