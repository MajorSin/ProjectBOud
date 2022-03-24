/*
 * PROJECT B
 * Food products menu by Ferdi and Anouar - 1006990 1035842
*/


using System;
// Start menu application
class App
{
    // Initialise display and select methods
    static void Main(string[] args)
    {
        bool showMenu = true; 
        while (showMenu)
        {
            showMenu = DisplayMenu();
            showMenu = SelectMenu();
        }
    }
    // Define display method
    public static bool DisplayMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("\nDit is een overzicht van het menu\n");

        var overviewMenu = new List<string>();
        overviewMenu.Add("|1- Popcorn");
        overviewMenu.Add("|2- Nachos");
        overviewMenu.Add("|3- Chips");
        overviewMenu.Add("|4- Cola");
        overviewMenu.Add("|5- Sprite");
        overviewMenu.Add("|6- Water");
        overviewMenu.Add("|7- Ijs");

        foreach (var item in overviewMenu)
        {
            Console.WriteLine(item);
   
        } 

        Console.WriteLine("\n---------------------------------");
        Console.WriteLine("to see more info press the number of the product");
        string yesnes = Console.ReadLine();
        if (yesnes == "1")
        {
            Console.WriteLine("info  portie popcorn");
            Console.WriteLine("calorieën: 155");
            Console.WriteLine("koolhydraten: 5 gram");
            Console.WriteLine("vetten: 10 gram");
            Console.WriteLine("eiwitten: 2 gram");
        }
        else if (yesnes == "2")
        {
            Console.WriteLine("info  portie nachos");
            Console.WriteLine("calorieën: 370");
            Console.WriteLine("koolhydraten: 51 gram");
            Console.WriteLine("vetten: 17 gram");
            Console.WriteLine("eiwitten: 6 gram");
        }
        else if (yesnes == "3")
        {
            Console.WriteLine("info zakje chips");
            Console.WriteLine("calorieën: 240");
            Console.WriteLine("koolhydraten: 23 gram");
            Console.WriteLine("vetten:  15 gram");
            Console.WriteLine("eiwitten: 3 gram");
        }
        else if (yesnes == "4")
        {
            Console.WriteLine("info  cola");
            Console.WriteLine("calorieën: 139");
            Console.WriteLine("koolhydraten: 35 gram");
            Console.WriteLine("vetten: 0 gram");
            Console.WriteLine("eiwitten: 0 gram");
        }
        else if (yesnes == "5")
        {
            Console.WriteLine("info  sprite");
            Console.WriteLine("calorieën: 92");
            Console.WriteLine("koolhydraten: 22 gram");
            Console.WriteLine("vetten: 0 gram");
            Console.WriteLine("eiwitten: 0 gram");
        }
        else if (yesnes == "6")
        {
            Console.WriteLine("info  water");
            Console.WriteLine("calorieën: 0");
            Console.WriteLine("koolhydraten: 0 gram");
            Console.WriteLine("vetten:  0 gram");
            Console.WriteLine("eiwitten: 0 gram");
        }
        else if(yesnes == "7")
        {
            Console.WriteLine("info  ijs");
            Console.WriteLine("calorieën: 40");
            Console.WriteLine("koolhydraten: 10 gram");
            Console.WriteLine("vetten:  0,5 gram");
            Console.WriteLine("eiwitten: 0 gram");
        }
        return false;
        
    }
    // Define select method
    public static bool SelectMenu()
    {
        // Error handler
        Console.Write("\nPress 'Enter' to exit the process...");
        string key = Console.ReadKey().Key.ToString();

        if (key == "")
        {
            Console.Clear();
        }

        else
        {
            Console.Write("\nOther key input detected, make sure to press 'Enter''");
            Console.Read();
        }

        return false;
    }
}
/*
 * More to come
 * First concept built
 */