using System;
using System.Collections.Generic;
using System.Linq;

namespace SchermTonen
{
    public class Program
    {
        static List<User> users = new List<User>();

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool IsLoggedIn { get; set; }
        }

        public class Router
        {
            public string CurrentScreen { get; set; }

            // Toont het scherm waar je nu op bent.
            public void displayScreen()
            {
                switch (CurrentScreen) {
                    case "Authorizatie":
                        displayAuthorization();
                        break;
                    case "Inloggen":
                        displayInloggen();
                        break;
                    case "Registreren":
                        displayRegistreren();
                        break;
                    case "Home":
                        displayHome();
                        break;
                    case "Reserveren":
                        displayReserveren();
                        break;
                    case "Films":
                        displayFilms();
                        break;
                    case "Eten & Drinken":
                        displayEtenDrinken();
                        break;
                    case "Informatie":
                        displayInformatie();
                        break;
                    default:
                        CurrentScreen = "Authorizatie";
                        displayAuthorization();
                        break;
                }
            }

            // Keuze van de gebruiker vaststellen.
            private int awaitResponse(string[] options)
            {
                int currentSelected = 0;
                bool selectionMade = false;

                // Loopt door de opties en houdt bij welke keuze je maakt met pijltjestoetsen.
                while (!selectionMade)
                {
                    for (int i = 0; i < options.Length; i++)
                    {
                        if (i == currentSelected)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }
                        Console.WriteLine("  {0}", options[i]);
                        Console.ResetColor();
                    }
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentSelected == 0)
                            {
                                break;
                            }
                            else
                            {
                                currentSelected -= 1;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentSelected == options.Length - 1)
                            {
                                break;
                            }
                            else
                            {
                                currentSelected += 1;
                            }
                            break;
                        case ConsoleKey.Enter:
                            selectionMade = true;
                            break;
                    }
                    // Zorgt ervoor dat de keuzes niet met elkaar gaan overlappen.
                    Console.CursorTop = Console.CursorTop - options.Length;
                }
                return currentSelected;
            }

            // Authorisatie scherm.
            private void displayAuthorization()
            {
                ConsoleColor color = ConsoleColor.White;
                string title = @"
              __________
           ///^^^^{}^^^^\\\
         //..@----------@..\\
        ///&%&%&%&/\&%&%&%&\\\
        ||&%&%&_.'  '._&%&%&||
        ||&%'''        '''%&||
        ||&%&  Bioscoop  &%&||
        ||&%&             %&||
        ||&%&            &%&||
  ______||&%&&==========&&%&||______
                ";
                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                string[] options = new string[]
                {
                    "Inloggen",
                    "Registreren",
                    "Doorgaan als gast",
                    "Beeïndigen",
                };

                int choice = awaitResponse(options);

                switch (choice)
                {
                    case 0:
                        CurrentScreen = "Inloggen";
                        Console.Clear();
                        displayScreen();
                        break;
                    case 1:
                        CurrentScreen = "Registreren";
                        Console.Clear();
                        displayScreen();
                        break;
                    case 2:
                        CurrentScreen = "Home";
                        Console.Clear();
                        displayScreen();
                        break;
                    default:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }

            // Lay-out van de header teruggeven.
            private void showHeader(ConsoleColor color, string title, string underline)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(@"{0}", title);
                Console.BackgroundColor = color;
                Console.WriteLine(underline);
                Console.ResetColor();
            }

            // Inlog scherm.
            private void displayInloggen()
            {
                ConsoleColor color = ConsoleColor.Cyan;
                string title = @"
   _____           _                                        
  |_   _|         | |                                       
    | |    _ __   | |   ___     __ _    __ _    ___   _ __  
    | |   | '_ \  | |  / _ \   / _` |  / _` |  / _ \ | '_ \ 
   _| |_  | | | | | | | (_) | | (_| | | (_| | |  __/ | | | |
  |_____| |_| |_| |_|  \___/   \__, |  \__, |  \___| |_| |_|
                               __/ |   __/ |               
                              |___/   |___/
                ";
                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                Console.WriteLine("[inloggen inhoud]\n");

                string[] options = new string[]
                {
                    "Terug",
                    "Beeïndigen"
                };

                int choice = awaitResponse(options);

                if (choice == 0)
                {
                    CurrentScreen = "Authorizatie";
                    Console.Clear();
                    displayScreen();
                }
                else
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }

            // Registratie scherm.
            private void displayRegistreren()
            {
                ConsoleColor color = ConsoleColor.Cyan;
                string title = @"
   _____                   _         _                                       
  |  __ \                 (_)       | |                                      
  | |__) |   ___    __ _   _   ___  | |_   _ __    ___   _ __    ___   _ __  
  |  _  /   / _ \  / _` | | | / __| | __| | '__|  / _ \ | '__|  / _ \ | '_ \ 
  | | \ \  |  __/ | (_| | | | \__ \ | |_  | |    |  __/ | |    |  __/ | | | |
  |_|  \_\  \___|  \__, | |_| |___/  \__| |_|     \___| |_|     \___| |_| |_|
                   __/ |                                                    
                  |___/    

                ";

                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                Console.WriteLine("[registreren inhoud]\n");

                string[] options = new string[]
                {
                    "Terug",
                    "Beeïndigen"
                };

                int choice = awaitResponse(options);

                if (choice == 0)
                {
                    CurrentScreen = "Authorizatie";
                    Console.Clear();
                    displayScreen();
                }
                else
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }
            // Hoofdscherm.
            private void displayHome()
            {
                int currentHour = DateTime.Now.Hour;
                Func<int, string> greeting = hour =>
                {
                    switch (hour)
                    {
                        case < 12:
                            return "Goedemorgen,";
                        case >= 12 and < 18:
                            return "Goedemiddag,";
                        default:
                            return "Goedenavond,";
                    }
                };

                ConsoleColor color =  ConsoleColor.White;
                string result = greeting(currentHour);
                string name = "";

                if (!users.Any())
                {
                    name = "gast";   
                }

                string title = @$"     
                            ___________I____________
                           ( _____________________ ()
                         _.-'|                    ||
                     _.-'   ||     {result}   ||
    ______       _.-'       ||        {name}!       ||
   |      |_ _.-'           ||                    ||
   |      |_|_              ||      Welkom op     ||
   |______|   `-._          ||         het        ||
      /\          `-._      ||     hoofdscherm.   ||
     /  \             `-._  ||                    ||
    /    \                `-||____________________||
   /      \                 ------------------------
  /________\___________________/________________\______
                ";

                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                string[] options = new string[] {
                    "Reserveren",
                    "Films",
                    "Eten & Drinken",
                    "Informatie",
                    "Terug"
                };

                int choice = awaitResponse(options);
                if (choice == options.Length - 1)
                {
                    CurrentScreen = "Authorization";
                }
                else
                {
                    CurrentScreen = options[choice];
                }

                Console.Clear();
                displayScreen();
            }

            // Reserveer scherm.
            private void displayReserveren()
            {
                ConsoleColor color = ConsoleColor.Magenta;
                string title = @"
   _____                                                                  
  |  __ \                                                                 
  | |__) |   ___   ___    ___   _ __  __   __   ___   _ __    ___   _ __  
  |  _  /   / _ \ / __|  / _ \ | '__| \ \ / /  / _ \ | '__|  / _ \ | '_ \ 
  | | \ \  |  __/ \__ \ |  __/ | |     \ V /  |  __/ | |    |  __/ | | | |
  |_|  \_\  \___| |___/  \___| |_|      \_/    \___| |_|     \___| |_| |_|
                                                                                       
                ";
                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                Console.WriteLine("[reserveren inhoud]\n");

                string[] options = new string[]
                {
                    "Terug",
                    "Beeïndigen"
                };

                int choice = awaitResponse(options);

                if (choice == 0)
                {
                    CurrentScreen = "Home";
                    Console.Clear();
                    displayScreen();
                } 
                else
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }

            // Films scherm.
            private void displayFilms()
            {
                ConsoleColor color = ConsoleColor.Blue;
                string title = @"
   ______   _   _                   
  |  ____| (_) | |                  
  | |__     _  | |  _ __ ___    ___ 
  |  __|   | | | | | '_ ` _ \  / __|
  | |      | | | | | | | | | | \__ \
  |_|      |_| |_| |_| |_| |_| |___/
                                 
                ";
                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                Console.WriteLine("[films inhoud]\n");

                string[] options = new string[]
                {
                    "Terug",
                    "Beeïndigen"
                };

                int choice = awaitResponse(options);

                if (choice == 0)
                {
                    CurrentScreen = "Home";
                    Console.Clear();
                    displayScreen();
                }
                else
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }

            // Eten & Drinken scherm.
            private void displayEtenDrinken()
            {
                ConsoleColor color = ConsoleColor.Red;
                string title = @"
   ______   _                                 _____           _           _                   
  |  ____| | |                      ___      |  __ \         (_)         | |                  
  | |__    | |_    ___   _ __      ( _ )     | |  | |  _ __   _   _ __   | | __   ___   _ __  
  |  __|   | __|  / _ \ | '_ \     / _ \/\   | |  | | | '__| | | | '_ \  | |/ /  / _ \ | '_ \ 
  | |____  | |_  |  __/ | | | |   | (_>  <   | |__| | | |    | | | | | | |   <  |  __/ | | | |
  |______|  \__|  \___| |_| |_|    \___/\/   |_____/  |_|    |_| |_| |_| |_|\_\  \___| |_| |_|
                                                                                                      
                ";
                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                Console.WriteLine("[eten & drinken inhoud]\n");

                string[] options = new string[]
                {
                    "Terug",
                    "Beeïndigen"
                };

                int choice = awaitResponse(options);

                if (choice == 0)
                {
                    CurrentScreen = "Home";
                    Console.Clear();
                    displayScreen();
                }
                else
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }

            // Informatie scherm.
            private void displayInformatie()
            {
                ConsoleColor color = ConsoleColor.Green;
                string title = @"
   _____            __                                      _     _        
  |_   _|          / _|                                    | |   (_)       
    | |    _ __   | |_    ___    _ __   _ __ ___     __ _  | |_   _    ___ 
    | |   | '_ \  |  _|  / _ \  | '__| | '_ ` _ \   / _` | | __| | |  / _ \
   _| |_  | | | | | |   | (_) | | |    | | | | | | | (_| | | |_  | | |  __/
  |_____| |_| |_| |_|    \___/  |_|    |_| |_| |_|  \__,_|  \__| |_|  \___|
                                                                                 
                ";
                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                Console.WriteLine("[informatie inhoud]\n");

                string[] options = new string[]
                {
                    "Terug",
                    "Beeïndigen"
                };

                int choice = awaitResponse(options);

                if (choice == 0)
                {
                    CurrentScreen = "Home";
                    Console.Clear();
                    displayScreen();
                }
                else
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }

            static void Main(string[] args)
            {
                // Maakt een Router instantie om te gebruiken voor de schermen.
                Router router = new Router();
                router.displayScreen();
            }
        }
    }
}
