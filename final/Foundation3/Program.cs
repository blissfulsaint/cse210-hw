using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("42 S 1st W", "Rexburg", "Idaho", "USA");
        Address address2 = new Address("2904 Willowdale Ct", "McKinney", "Texas", "USA");
        Address address3 = new Address("5612 Fruitwood Dr", "McKinney", "Texas", "USA");

        Lecture event1 = new Lecture("Brandon Lisonbee on the true origin of Moebius", "Local Xenoblade professional Brandon Lisonbee will be instructing fellow story connisseurs regarding the evidences there are for how Moebius came to be in the world and story of Xenoblade Chronicles 3 for the Nintendo Switch entertainment system.", "2023-07-20", "6:00 PM", address1, "Brandon Lisonbee", 150);
        List<Event> events = new List<Event>();
        events.Add(event1);

        Reception event2 = new Reception("Wedding Reception for Caden Dodson and Talia Harper", "A wedding reception following the sealing of Caden Dodson and Talia Harper in the Rexburg, Idaho temple. Food and games will be included.", "2023-07-29", "3:00 PM", address2, "dodsonwedding@gmail.com");
        events.Add(event2);

        OutdoorGathering event3 = new OutdoorGathering("BYU-Idaho 120th Ward Closing Social", "All members of the BYU-Idaho YSA 120th Ward and their friends are invited to play games, eat sandwiches, have some ice cream floats, and watch a movie with us!", "2023-07-17", "7:00 PM", address3, "Partly Cloudy");
        events.Add(event3);

        for (int i = 0; i < events.Count(); i++)
        {
            events[i].DisplayBriefDetails();
            events[i].DisplayStandardDetails();
            events[i].DisplayFullDetails();
        }
    }
}