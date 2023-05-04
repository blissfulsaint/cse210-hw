using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._jobTitle = "Software Engineer";
        job1._company = "USAA";
        job1._startYear = 2019;
        job1._endYear = 2023;

        Job job2 = new Job();

        job2._jobTitle = "Web Developer";
        job2._company = "Microsoft";
        job2._startYear = 2012;
        job2._endYear = 2018;

        job1.DisplayJobDetails();
        job2.DisplayJobDetails();


    }
}