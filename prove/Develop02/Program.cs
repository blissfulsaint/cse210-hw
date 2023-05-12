File file = new File();
Menu menu = new Menu(file);

menu.DisplayFileMenu();

// So I think it should be readily apparent what I have
// done for the exceeding requirements thing, but I 
// added a TON of functionality to the program as a
// whole. Even though it is run entirely through CLI,
// there is an extensive menu with an option even to 
// change settings such as the separator characters. 
// I also included the prompts as txt files and the 
// special chars as well so that all of these are 
// saved outside of runtime. Lastly, there is a list
// of journal files in a txt file as well to assist
// with iteration when changing the separator string.
// All of this functionality is in the menu class, and
// it took me hours to write so I don't really want to
// explain it here. I know I was really extra and I 
// probably didn't need to do all of this, but I had a
// lot of fun with it so it was worth it.

// As a final note, you may notice that there are some
// methods, particularly in the journal class, that went
// unused. I intend to continue building on this program
// in the future, and those are entirely extra, but that
// is why they are there. 