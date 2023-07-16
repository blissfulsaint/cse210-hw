public class Menu
{
    User _user = new User();
    File _file = new File();
    string _userFileName = "";
    string _specialCharsFileName = "specialChars.txt";
    string _userFilesName = "userFiles.txt";
    List<string> _specialCharsList = new List<string>();
    List<string> _userFilesList = new List<string>();
    string _stringSeparator;

    private string RemoveSpecialChar(string str)
    {
        return str.Replace(_stringSeparator, "");
    }

    private void LoadSpecialChars()
    {
        _specialCharsList.Clear();

        _file.SetFileName(_specialCharsFileName);
        string[] lines = _file.LoadFile();
        _file.SetFileName(_userFileName);

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
        _userFilesList.Clear();

        _file.SetFileName(_userFilesName);
        string[] lines = _file.LoadFile();
        _file.SetFileName(_userFileName);

        foreach (string line in lines)
        {
            _userFilesList.Add(line);
        }

        _userFilesList = _userFilesList.Distinct().ToList();
    }

    private void SaveFileNames()
    {
        _userFilesList = _userFilesList.Distinct().ToList();
        _file.SetFileName(_userFilesName);
        _file.SaveFile(_userFilesList);
        _file.SetFileName(_userFileName);
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
        foreach (string fileName in _userFilesList)
        {
            _stringSeparator = oldSeparator;
            _file.SetFileName(fileName);
            LoadUser();
            _stringSeparator = newChar;
            SaveUser();
        }
        _file.SetFileName(_userFileName);
        LoadUser();

        Console.WriteLine("Separator successfully changed!");
    }

    public void LoadUser()
    {

    }

    public void SaveUser()
    {
        List<string> lines = new List<string>();
        List<Goal> goals = _user.GetGoals();

        lines.Add("--- User File ---");
        lines.Add($"!>name: {_user.GetName()}");
        lines.Add($"!>points: {_user.GetPoints()}");

        foreach (Goal goal in goals)
        {
            if (goal.GetType() == "SimpleGoal" || goal.GetType() == "EternalGoal")
            {
                lines.Add($"{goal.GetType()}:{goal.GetGoal()}{_stringSeparator}{goal.GetDescription()}{_stringSeparator}{goal.GetPoints()}{_stringSeparator}{goal.GetCompletionStatus()}");
            }
            else if (goal.GetType() == "ChecklistGoal")
            {
                ChecklistGoal tempGoal = (ChecklistGoal)goal;
                lines.Add($"{tempGoal.GetType()}:{tempGoal.GetGoal()}{_stringSeparator}{tempGoal.GetDescription()}{_stringSeparator}{tempGoal.GetPoints()}{_stringSeparator}{tempGoal.GetCompletionStatus()}{_stringSeparator}{tempGoal.GetCompletionGoal()}{_stringSeparator}{tempGoal.GetBonusPoints()}{_stringSeparator}{tempGoal.GetTimesCompleted()}");
            }
        }

        _file.SaveFile(lines);
    }

    public void DisplayFileMenu()
    {
        LoadSpecialChars();
        LoadFileNames();

        string response = "";
        string[] options = {"1", "2", "3", "4", "5", "6"};
        
        Console.Clear();

        while (response != "6")
        {
            response = "";
            while (options.Contains(response) == false)
            {
                Console.WriteLine("Menu Options: \n1. Create New Goal \n2. List Goals \n3. Save Goals \n4. Load Goals \n5. Record Event \n6. Quit \nSelect a choice from the menu: ");
                response = Console.ReadLine() ?? String.Empty;
            }
            switch (response)
            {
                case "1":
                    CreateGoalMenu();
                    break;
                case "2":
                    Console.Clear();
                    _user.DisplayGoals();
                    break;
                case "3":
                    _userFileName = _file.GetFileName();

                    while (_user.GetName() == "" || _user.GetName() == _stringSeparator)
                    {
                        Console.Write("Please enter a name for this user: ");
                        string newUserName = Console.ReadLine();

                        _user.SetName(newUserName);
                    }
                    while (_userFileName.Length <= 4 || _userFileName.Substring(_userFileName.Length - 4) != ".txt")
                    {
                        Console.Write("Please enter a .txt file name to save this as: ");
                        _userFileName = Console.ReadLine();
                    }
                    _file.SetFileName(_userFileName);
                    SaveUser();

                    Console.WriteLine("User successfully saved!");
                    break;
                case "4":
                    Console.Write("What is the name of the user file you would like to load? ");
                    _userFileName = Console.ReadLine() ?? String.Empty;

                    while (_userFileName.Length <= 4 || _userFileName.Substring(_userFileName.Length - 4) != ".txt")
                    {
                        Console.Write("Please enter a .txt file name to read from: ");
                        _userFileName = Console.ReadLine();
                    }
                    _file.SetFileName(_userFileName);

                    LoadUser();
                    break;
                case "5":
                    _user.DisplayGoals();

                    int indexResponse = -1;
                    while (indexResponse < 0 || indexResponse >= _user.GetGoals().Count())
                    {
                        Console.Write("Please enter the index of a goal you would like to record an event for: ");
                        indexResponse = int.Parse(Console.ReadLine());
                    }
                    _user.RecordGoal(indexResponse);
                    Console.WriteLine("Event successfully recorded!");
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private void CreateGoalMenu()
    {
        string response = "";
        string[] options = {"1", "2", "3", "4"};

        while (response != "4")
        {
            // string goal;
            // string description;
            // int points;
            // int completionGoal;
            // int bonusPoints;

            response = "";
            while (!options.Contains(response))
            {
                Console.WriteLine("Goal Menu: \n1. Create Simple Goal \n2. Create Eternal Goal \n3. Create Checklist Goal \n4. Quit \nWhat would you like to do?");
                response = Console.ReadLine() ?? String.Empty;
                response = response.ToUpper();
            }
            switch (response)
            {
                case "1":
                    Console.Write("What is your goal? ");
                    string goal = Console.ReadLine();
                    Console.Write("Please describe your goal: ");
                    string description = Console.ReadLine();
                    Console.Write("How many points is this goal worth? ");
                    int points = int.Parse(Console.ReadLine());

                    SimpleGoal simpleGoal = new SimpleGoal(goal, description, points);
                    _user.AddGoal(simpleGoal);

                    Console.WriteLine("Goal successfully added!");
                    break;
                case "2":
                    Console.Write("What is your goal? ");
                    goal = Console.ReadLine();
                    Console.Write("Please describe your goal: ");
                    description = Console.ReadLine();
                    Console.Write("How many points is this goal worth? ");
                    points = int.Parse(Console.ReadLine());

                    EternalGoal eternalGoal = new EternalGoal(goal, description, points);
                    _user.AddGoal(eternalGoal);

                    Console.WriteLine("Goal successfully added!");
                    break;
                case "3":
                    Console.Write("What is your goal? ");
                    goal = Console.ReadLine();
                    Console.Write("Please describe your goal: ");
                    description = Console.ReadLine();
                    Console.Write("How many points is this goal worth? ");
                    points = int.Parse(Console.ReadLine());
                    Console.Write("How many times does this need to be done for bonus points? ");
                    int completionGoal = int.Parse(Console.ReadLine());
                    Console.Write("How much bonus points will you earn by completing this goal? ");
                    int bonusPoints = int.Parse(Console.ReadLine());

                    ChecklistGoal checklistGoal = new ChecklistGoal(goal, description, points, completionGoal, bonusPoints);
                    _user.AddGoal(checklistGoal);

                    Console.WriteLine("Goal successfully added!");
                    break;
                case "4":
                    break;
            }
        }
    }
}