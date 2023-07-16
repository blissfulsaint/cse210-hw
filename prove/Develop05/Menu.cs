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

    }
}