using System;

// As you can see in this program file, I added the ability to load scriptures from a txt file and pick a random one. As of right now, there are only two scriptures in the file, but if you were to add more under the same format, they will be a part of the program

class Program
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("scriptures.txt");

        List<Scripture> scriptures = new List<Scripture>();

        foreach (string line in lines)
        {
            string[] parts = line.Split("?>");

            string scriptureReference = parts[0];
            string verses = parts[1];

            string book;
            int chapter;
            int firstVerse;
            int lastVerse;

            string[] parts1 = scriptureReference.Split(">");
            book = parts1[0];

            string[] parts2 = parts1[1].Split(":");
            chapter = int.Parse(parts2[0]);

            if (parts2[1].Contains("-"))
            {
                string[] parts3 = parts2[1].Split("-");

                firstVerse = int.Parse(parts3[0]);
                lastVerse = int.Parse(parts3[1]);
            }
            else
            {
                firstVerse = int.Parse(parts2[1]);
                lastVerse = int.Parse(parts2[1]);
            }

            Reference reference = new Reference(book, chapter, firstVerse, lastVerse);
            Scripture scripture = new Scripture(verses, reference);

            scriptures.Add(scripture);
        }

        Random rand = new Random();
        scriptures[rand.Next(0, scriptures.Count())].Display();
    }
}