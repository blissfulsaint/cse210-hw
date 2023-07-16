using System;

class Program
{
    static void Main(string[] args)
    {
        Running activity1 = new Running("07 Jul 2023", 28, 4.5);
        Cycling activity2 = new Cycling("01 Jul 2023", 20, 25);
        Swimming activity3 = new Swimming("13 May 2023", 15, 19);

        List<Activity> activities = new List<Activity>();

        activities.Add(activity1);
        activities.Add(activity2);
        activities.Add(activity3);

        foreach(Activity activity in activities)
        {
            activity.DisplaySummary();
        }
    }
}