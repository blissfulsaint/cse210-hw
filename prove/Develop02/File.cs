using System.IO;

public class File
{
    string _currentDir;
    string _fileName;

    public string[] LoadFile()
    {
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        return lines;
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
}