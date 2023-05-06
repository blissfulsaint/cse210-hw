public class Resume
{
    public string _name;
    public List<Job> _jobList = new List<Job>();

    public Resume(string name)
    {
        _name = name;
    }

    public void DisplayResumeDetails()
    {
        Console.WriteLine($"Name: {_name}");

        Console.WriteLine("Jobs:");

        foreach (Job job in _jobList)
        {
            job.DisplayJobDetails();
        }
    }
}