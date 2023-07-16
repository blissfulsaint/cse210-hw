using System;

class Program
{
    static void Main(string[] args)
    {
        string title = "Riding ALL rides in disneyland in ONE DAY";
        string author = "Alpharad";
        int length = 1287;
        Comment alpharadComment1 = new Comment("BlissfulSaint99", "this is one of the most alpharad things to ever alpharad");
        Comment alpharadComment2 = new Comment("someguy", "I'd definitely throw up");
        Comment alpharadComment3 = new Comment("kirsten beard", "why am I watching this");

        List<Comment> comments = new List<Comment>();
        comments.Add(alpharadComment1);
        comments.Add(alpharadComment2);
        comments.Add(alpharadComment3);

        Video alpharad = new Video(title, author, length, comments);
        List<Video> videos = new List<Video>();
        videos.Add(alpharad);

        Console.WriteLine("");

        comments.Clear();


        title = "Wii Play, Do You?";
        author = "Scott the Woz";
        length = 1045;
        Comment scottComment1 = new Comment("BlissfulSaint99", "I freaking loved this game as a kid");
        Comment scottComment2 = new Comment("someguy", "never played this game growing up but now I feel like Nintendo is threatening me if I don't");
        Comment scottComment3 = new Comment("kirsten beard", "my brother is the exact type of person to do everything scott does");
        
        comments.Add(scottComment1);
        comments.Add(scottComment2);
        comments.Add(scottComment3);

        Video scott = new Video(title, author, length, comments);
        videos.Add(scott);

        Console.WriteLine("");

        comments.Clear();


        title = "Tipping has gotten out of control";
        author = "The Comments Section with Brett Cooper";
        length = 902;
        Comment brettComment1 = new Comment("BlissfulSaint99", "I have simple tipping rules. I never tip unless I feel the person I am tipping really earned it, even in service industry. If someone gives me attitude the whole time, I do not feel inclined to give them my money.");
        Comment brettComment2 = new Comment("someguy", "I'm too poor to tip anyways");
        Comment brettComment3 = new Comment("kirsten beard", "brett is my spirit animal");

        comments.Add(brettComment1);
        comments.Add(brettComment2);
        comments.Add(brettComment3);

        Video brett = new Video(title, author, length, comments);
        videos.Add(brett);

        foreach(Video video in videos)
        {
            video.DisplayDetails();
        }
    }
}