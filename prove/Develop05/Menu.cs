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
        string[] lines = _file.LoadFile();

        if (lines == null)
        {
            Console.WriteLine("No User file was found with that filename.");
        }
        else if (lines[0] == "--- User File ---")
        {
            List<Goal> newGoalsList = new List<Goal>();
            string newUserName = "";
            int newUserPoints = 0;

            foreach (string line in lines)
            {
                if (line.Contains("!>name: "))
                {
                    newUserName = line.Replace("!>name: ", "");
                }
                else if (line.Contains("!>points: "))
                {
                    newUserPoints = int.Parse(line.Replace("!>points: ", ""));
                }
                else if (line != "--- User File ---")
                {
                    string[] parts = line.Split(_stringSeparator);
                    string[] goalParts = parts[0].Split(":");

                    string goal = goalParts[1];
                    string description = parts[1];
                    int points = int.Parse(parts[2]);
                    bool isComplete = bool.Parse(parts[3]);

                    if (goal == "SimpleGoal")
                    {
                        SimpleGoal newGoal = new SimpleGoal(goal, description, points, isComplete);
                        newGoalsList.Add(newGoal);
                    }
                    else if (goal == "EternalGoal")
                    {
                        EternalGoal newGoal = new EternalGoal(goal, description, points, isComplete);
                        newGoalsList.Add(newGoal);
                    }
                    else if (goal == "ChecklistGoal")
                    {
                        int completionGoal = int.Parse(parts[4]);
                        int bonusPoints = int.Parse(parts[5]);
                        int timesCompleted = int.Parse(parts[6]);

                        ChecklistGoal newGoal = new ChecklistGoal(goal, description, points, completionGoal, bonusPoints, timesCompleted);
                        newGoalsList.Add(newGoal);
                    }
                }

                User newUser = new User(newUserName, newUserPoints, newGoalsList);
                _user = newUser;
            }
        }
        else 
        {
            Console.WriteLine("This does not appear to be a user file");
        }
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
                lines.Add($"{goal.GetType()}:{goal.GetGoal}{_stringSeparator}{goal.GetDescription}{_stringSeparator}{goal.GetPoints()}{_stringSeparator}{goal.GetCompletionStatus()}");
            }
            else if (goal.GetType() == "ChecklistGoal")
            {
                ChecklistGoal tempGoal = (ChecklistGoal)goal;
                lines.Add($"{tempGoal.GetType()}:{tempGoal.GetGoal}{_stringSeparator}{tempGoal.GetDescription}{_stringSeparator}{tempGoal.GetPoints()}{_stringSeparator}{tempGoal.GetCompletionStatus()}{_stringSeparator}{tempGoal.GetCompletionGoal()}{_stringSeparator}{tempGoal.GetBonusPoints()}{_stringSeparator}{tempGoal.GetTimesCompleted()}");
            }
        }

        _file.SaveFile(lines);
    }
}