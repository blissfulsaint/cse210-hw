Player michael = new Player("Michael the Goat", "Jordan", 23);

michael.UpdateJersey(45);
michael.UpdateJersey(23);

michael.Display();

Player axa = new Player("Axa", "Uribe", 10);


Team fireballs = new Team("Fireballs");

fireballs.AddPlayer(axa);
fireballs.AddPlayer(michael);

fireballs.AddWin();
fireballs.AddLoss();
fireballs.AddWin();

fireballs.Display();


Player kendra = new Player("Kendra", "Sorensen", 1);
Player seth = new Player("Seth", "Sorensen", 7);
Player bracken = new Player("Bracken", "Unknown", 1);

Team fables = new Team("Fables");
fables.AddPlayer(kendra);
fables.AddPlayer(seth);
fables.AddLoss();
fables.AddWin();
fables.AddLoss();
fables.AddWin();
fables.AddWin();
fables.AddPlayer(bracken);

fables.Display();


Match fablesVFireballs = new Match(fables, fireballs);
fablesVFireballs.DecideWin();

fireballs.Display();
fables.Display();