// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Dvd dvd1 = new Dvd("Finding Nemo");
dvd1.CheckOut();
dvd1.Display();


Book findingDory = new Book("Finding Dory", "978-10000302", 551000002);
findingDory.CheckOut();

findingDory.Display();