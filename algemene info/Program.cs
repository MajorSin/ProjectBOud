class prakticalInformation
{
    public static void Main()
    {
        Console.WriteLine("Hier vindt u de algemene informatie over de bioscoop.");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Adres:    Wijnhaven 107, Rotterdam");
        Console.WriteLine("Postcode: 3011 WN");
        Console.WriteLine("");
        Console.Write("Openingstijden:");
        Console.WriteLine("    Maandag:      09:00 - 22:00");
        Console.WriteLine("                   Dinsdag:      09:00 - 22:00");
        Console.WriteLine("                   Woensdag:     09:00 - 22:00");
        Console.WriteLine("                   Donderdag:    09:00 - 22:00");
        Console.WriteLine("                   Vrijdag:      09:00 - 00:00");
        Console.WriteLine("                   Zaterdag:     09:00 - 00:00");
        Console.WriteLine("                   Zondag:       09:00 - 22:00");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write("Wilt u terug naar het hoofdscherm? druk dan eerst op \"1\" en druk daarna op \"Enter\" ");
        string userInput = Console.ReadLine(); // leest de user input en zet die input in de variable 'userinput'
        while (userInput != "1")
        {
            Console.Write("Ongeldige invoer, druk a.u.b. op \"1\" en daarna op \"Enter\" ");
            userInput = Console.ReadLine(); // leest de user input en zet die input in de variable 'userinput'
        }
        if (userInput == "1")
        {
            Environment.Exit(0); // sluit de console als de user op 1 drukt
        }
    }
}