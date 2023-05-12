using System;
using System.IO;

public class Menu
{
    Journal _journal = new Journal();
    File _file = new File();
    string _journalFileName = "";
    string _specialCharsFileName = "specialChars.txt";
    string _journalFilesName = "journalFiles.txt";
    List<string> _specialCharsList = new List<string>();
    List<string> _journalFilesList = new List<string>();
    string _stringSeparator;

    public Menu(File file)
    {
        _file = file;
    }

    private string RemoveSpecialChar(string str)
    {
        return str.Replace(_stringSeparator, "");
    }

    private void LoadSpecialChars()
    {
        _specialCharsList.Clear();

        _file.SetFileName(_specialCharsFileName);
        string[] lines = _file.LoadFile();
        _file.SetFileName(_journalFileName);

        foreach (string line in lines)
        {
            if (line.Contains("_stringSeparator: "))
            {
                _stringSeparator = line.Replace("_stringSeparator: ", "");
            }
            _specialCharsList.Add(line);
        }
    }

    private void LoadFileNames()
    {
        _journalFilesList.Clear();

        _file.SetFileName(_journalFilesName);
        string[] lines = _file.LoadFile();
        _file.SetFileName(_journalFileName);

        foreach (string line in lines)
        {
            _journalFilesList.Add(line);
        }

        _journalFilesList = _journalFilesList.Distinct().ToList();
    }

    private void SaveFileNames()
    {
        _journalFilesList = _journalFilesList.Distinct().ToList();
        _file.SetFileName(_journalFilesName);
        _file.SaveFile(_journalFilesList);
        _file.SetFileName(_journalFileName);
    }

    private void ChangeStringSeparator(string newChar)
    {
        List<string> newCharList = new List<string>();
        foreach (string line in _specialCharsList)
        {
            if (line.Contains(_stringSeparator))
            {
                newCharList.Add(line.Replace(_stringSeparator, newChar));
            }
            else
            {
                newCharList.Add(line);
            }
        }
        _specialCharsList = newCharList;
        _file.SetFileName(_specialCharsFileName);
        _file.SaveFile(_specialCharsList);

        string oldSeparator = _stringSeparator;
        
        LoadFileNames();
        foreach (string fileName in _journalFilesList)
        {
            _stringSeparator = oldSeparator;
            _file.SetFileName(fileName);
            LoadJournal();
            _stringSeparator = newChar;
            SaveJournal();
        }
        _file.SetFileName(_journalFileName);
        LoadJournal();

        Console.WriteLine("Separator successfully changed!");
    }

    public void LoadJournal()
    {
        _journal.ClearEntries();
        string[] lines = _file.LoadFile();
        // List<Entry> entries = new List<Entry>();

        if (lines == null)
        {
            Console.WriteLine("No Journal file was found with that filename.");
        }
        else if (lines[0] == "--- Journal File ---")
        {
            foreach (string line in lines)
            {
                if (line != "--- Journal File ---")
                {
                    string [] parts = line.Split(_stringSeparator);

                    Entry entry = new Entry();

                    string dateString = parts[0];
                    DateTime date = new DateTime();
                    date = DateTime.Parse(dateString);
                    string prompt = parts[1];
                    string promptType = parts[2];
                    string response = parts[3];

                    entry.LogEntry(response, date, prompt, promptType);

                    _journal.InsertNewEntry(entry);
                }
            }
            Console.WriteLine("Journal successfully loaded!");
        }
        else
        {
            Console.WriteLine("This is not a Journal file. Please select a different file.");
        }
    }

    private Prompt LoadPromptList(string tempFileName)
    {
        string originalFileName = _file.GetFileName();
        _file.SetFileName(tempFileName);
        Prompt prompt = new Prompt(_file.LoadFile());
        _file.SetFileName(originalFileName);

        return prompt;
    }

    public void SaveJournal()
    {
        List<string> lines = new List<string>();
        List<Entry> entries = _journal.GetEntries();
        
        lines.Add("--- Journal File ---");

        foreach (Entry entry in entries)
        {
            string response = RemoveSpecialChar(entry.GetEntry());
            string prompt = RemoveSpecialChar(entry.GetPrompt());
            string promptType = RemoveSpecialChar(entry.GetPromptType());
            string date = RemoveSpecialChar(entry.GetDateString());

            lines.Add($"{date}{_stringSeparator}{prompt}{_stringSeparator}{promptType}{_stringSeparator}{response}");
        }

        _file.SaveFile(lines);
    }

    public void DisplayFileMenu()
    {
        LoadSpecialChars();
        LoadFileNames();
        string response = "";
        string[] options = {"L", "S", "E", "C", "Q", "O"};
        while (response != "Q")
        {
            response = "";
            while (options.Contains(response) == false)
            {
                Console.WriteLine("[L]oad Journal \n[S]ave Journal \n[E]dit Journal \n[C]reate New Journal \n[O]ther Settings \n[Q]uit \nWhat do you want to do?");
                response = Console.ReadLine() ?? String.Empty;
                response = response.ToUpper();
            }
            switch (response)
            {
                case "Q":
                    Environment.Exit(0);
                    break;
                case "L":
                    Console.Write("What is the name of the file you would like to load? ");
                    _journalFileName = Console.ReadLine() ?? String.Empty;

                    while (_journalFileName.Length <= 4 || _journalFileName.Substring(_journalFileName.Length - 4) != ".txt")
                    {
                        Console.Write("Please enter a .txt file name to read from: ");
                        _journalFileName = Console.ReadLine();
                    }
                    _file.SetFileName(_journalFileName);

                    LoadJournal();
                    break;
                case "C":
                    if (_journal.GetEntries().Count() != 0)
                    {
                        Console.Write("Creating a new journal will erase all unsaved progress on your current journal! Are you sure you want to proceed? (Y/N) ");
                        response = Console.ReadLine() ?? String.Empty;
                        response = response.ToUpper();

                        if (response != "Y")
                        {
                            break;
                        }
                    }
                    _journal.ClearEntries();
                    _journalFileName = "";
                    _file.SetFileName(_journalFileName);
                    Console.WriteLine("New Journal successfully created!");
                    break;
                case "S":
                    _journalFileName = _file.GetFileName();
                    while (_journalFileName.Length <= 4 || _journalFileName.Substring(_journalFileName.Length - 4) != ".txt")
                    {
                        Console.Write("Please enter a .txt file name to save this as: ");
                        _journalFileName = Console.ReadLine();
                    }
                    _file.SetFileName(_journalFileName);
                    SaveJournal();

                    _journalFilesList.Add(_journalFileName);
                    SaveFileNames();

                    Console.WriteLine("Journal successfully saved!");
                    break;
                case "E":
                    DisplayJournalMenu();
                    break;
                case "O":
                    DisplaySettingsMenu();
                    break;
            }
        }
    }

    private void DisplayJournalMenu()
    {
        string response = "";
        string[] options = {"A", "S", "F", "R"};
        while (response!="R")
        {
            response = "";
            while (options.Contains(response) == false)
            {
                Console.WriteLine("[A]dd Entry \n[S]how Entries \n[F]ind Entries \n[R]eturn to File Menu \n\nWhat do you want to do?");
                response = Console.ReadLine() ?? String.Empty;
                response = response.ToUpper();
            }
            switch (response)
            {
                case "R":
                    break;
                case "A":
                    DisplayAddMenu();
                    break;
                case "S":
                    DisplayShowMenu();
                    break;
                case "F":
                    Console.Write("Enter a keyword to search by: ");
                    response = Console.ReadLine();
                    _journal.SearchByKeyword(response);
                    response = "";
                    break;
            }
        }
    }

    private void DisplayAddMenu()
    {
        string response = "";
        string [] options = {"S", "N", "R"};
        while (response != "R")
        {
            response = "";
            while (options.Contains(response) == false)
            {
                Console.WriteLine("What sort of prompt would you like to receive? [S]piritual or [N]ormal? \n[R]eturn to Journal Menu");
                response = Console.ReadLine() ?? String.Empty;
                response = response.ToUpper();
            }
            switch (response)
            {
                case "R":
                    break;
                case "S":
                    DisplayPrompt("spiritualPrompts.txt");
                    break;
                case "N":
                    DisplayPrompt("temporalPrompts.txt");
                    break;
            }
        }
    }

    private void DisplayPrompt(string fileName)
    {
        Prompt promptList = LoadPromptList(fileName);
        string prompt = promptList.GetRandomPrompt();
        string promptType = promptList.GetType();

        Console.WriteLine(prompt);
        AddEntry(prompt, promptType);
    }

    private void AddEntry(string prompt, string promptType)
    {
        string response = Console.ReadLine();
        DateTime date = DateTime.Now;
        Entry entry = new Entry();
        entry.LogEntry(response, date, prompt, promptType);
        _journal.InsertNewEntry(entry);
    }

    private void DisplayShowMenu()
    {
        string response = "";
        string[] options = {"N", "O", "R"};
        
        while (response != "R")
        {
            response = "";
            while (options.Contains(response) == false)
            {
                Console.WriteLine("Would you like to show [N]ewest or [O]ldest entries first? \n[R]eturn to Journal Menu");
                response = Console.ReadLine() ?? String.Empty;
                response = response.ToUpper();
            }
            switch (response)
            {
                case "R":
                    break;
                case "N":
                    _journal.SortByDateDesc();
                    _journal.DisplayJournal();
                    break;
                case "O":
                    _journal.SortByDateAsc();
                    _journal.DisplayJournal();
                    break;
            }
        }
    }

    private void DisplaySettingsMenu()
    {
        string response = "";
        string [] options = {"C", "R"};

        while (response != "R")
        {
            response = "";
            while (options.Contains(response) == false)
            {
                Console.WriteLine("What would you like to do? \n[C]hange String Separator \n[R]eturn to File Menu");
                response = Console.ReadLine() ?? String.Empty;
                response = response.ToUpper();
            }
            switch (response)
            {
                case "R":
                    break;
                case "C":
                    Console.Write($"The current string separator is {_stringSeparator}. \nWhat would you like to change it to? ");
                    string newChar = Console.ReadLine();
                    ChangeStringSeparator(newChar);
                    break;
            }
        }
    }

    // private void DisplayFindMenu()
    // {
    //     string response = "";
    //     string[] options = {};
        
    //     while (response != "R")
    //     {
    //         response = "";
    //         while (options.Contains(response) == false)
    //         {
    //             Console.WriteLine("Would you like to show [N]ewest or [O]ldest entries first? \n[R]eturn to Journal Menu");
    //             response = Console.ReadLine() ?? String.Empty;
    //             response = response.ToUpper();
    //         }
    //         switch (response)
    //         {
    //             case "R":
    //                 break;
    //             case "N":
    //                 _journal.SortByDateDesc();
    //                 _journal.DisplayJournal();
    //                 break;
    //             case "O":
    //                 _journal.SortByDateAsc();
    //                 _journal.DisplayJournal();
    //                 break;
    //         }
    //     }
    // }
}