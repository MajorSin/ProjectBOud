class mainMenu
{
    public static void Main()
    {
        // Checkt de tijd en groet de gebruiker met deze informatie
        if (DateTime.Now.Hour < 12)
        {
            Console.WriteLine("Goedemorgen, Welkom bij insertName!");
        }
        else if (DateTime.Now.Hour < 18)
        {
            Console.WriteLine("Goedemiddag, Welkom bij insertName!");
        }
        else
        {
            Console.WriteLine("Goede avond, Welkom bij insertName!");
        }
        // Hoeveel pixels er van rechts af moeten om het plaatje goed uit te laten printen
        int pixelEraf = 30;
        // Het plaatje en keuzemenu uitprinten
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("  ___________________\n");
        Console.Write("U bevind zich op het hoofdscherm.");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write(" =|                 |     /\n");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("  | Insername Films |====||\n");
        Console.Write("Druk op \"1\" om ticktes te bestellen.");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("  |                 |====||\n");
        Console.Write("Druk op \"2\" om naar de actuele films te kijken.");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("  |                 | +   \\ \n");
        Console.Write("Druk op \"3\" om eten en drinken te kopen.");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("  -------------------\n");
        Console.Write("Druk op \"4\" voor de algemene informatie van de bioscoop.");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("        (--)\n");
        Console.Write("Druk op \"5\" om in te loggen.");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("        *  *\n");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("      *      *\n");
        Console.Write("Druk op \"6\" om de applicatie te sluiten.");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("    *          *\n");
        Console.CursorLeft = Console.BufferWidth - pixelEraf;
        Console.Write("  *              *\n");
        Console.Write("(Druk op \"Enter\" nadat u het cijfer heeft ingevult)\n");
        Console.Write("Uw keuze: ");
        string userKeuze = Console.ReadLine(); // Keuze van de gebruiker
        bool goedeKeuze = false; 
        if(userKeuze == "1" || userKeuze == "2" || userKeuze == "3" || userKeuze == "4" || userKeuze == "5" || userKeuze == "6") // Checkt of de userinput een valide keuze is
        {
            goedeKeuze = true;
        }
        while (!goedeKeuze) // De user moet een nieuwe input geven totdat hij een valide input geeft
        {
            Console.Write("Uw invoer is ongeldig. Kies Alst u blieft uit het keuzemenu hierboven: ");
            userKeuze = Console.ReadLine();
            if (userKeuze == "1" || userKeuze == "2" || userKeuze == "3" || userKeuze == "4" || userKeuze == "5" || userKeuze == "6")
            {
                goedeKeuze = true;
            }
        }
        if (userKeuze == "6") // Als de user op 6 drukt dan word de applicatie gesloten
        {
            Environment.Exit(0);
        }
    }
}