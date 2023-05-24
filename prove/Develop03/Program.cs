using System;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("scriptures.txt");

        List<Scripture> scriptures = new List<Scripture>();

        foreach (string line in lines)
        {
            string[] parts = line.Split("?>");

            string reference = parts[0];
            string[parts.Count() - 1] verses;
            
            for (int i = 0; i < verses.Count(); i++)
            {
                verses[i] = parts[i++];
                string[] verseParts = verses[i].Split(" - ");
            }
        }

        Reference reference = new Reference("1 Nephi", 3, 7);
        string scriptureText = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        Scripture scripture = new Scripture(scriptureText, reference);

        scripture.Display();
    }
}