using System;

namespace SchermTonen
{
    public class Program
    {
        public class Router
        {
            public string CurrentScreen { get; set; }

            // Toont het scherm waar je nu op bent.
            public void displayScreen()
            {
                if (string.IsNullOrEmpty(CurrentScreen))
                {
                    CurrentScreen = "Home";
                    displayHome();
                }
                else if (CurrentScreen == "Home")
                {
                    displayHome();
                }
                else if (CurrentScreen == "Reserveren")
                {
                    displayReserveren();
                }
                else if (CurrentScreen == "Films")
                {
                    displayFilms();
                }
                else if (CurrentScreen == "Eten & Drinken")
                {
                    displayEtenDrinken();
                }
                else if (CurrentScreen == "Informatie")
                {
                    displayInformatie();
                }
                else
                {
                    displayInloggen();
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

            // Lay-out van de header teruggeven.
            private void showHeader(ConsoleColor color, string title, string underline)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(@"{0}", title);
                Console.BackgroundColor = color;
                Console.WriteLine(underline);
                Console.ResetColor();
            }

            // Hoofdscherm.
            private void displayHome()
            {
                ConsoleColor color =  ConsoleColor.White;
                string title = @"
   _    _                    __       _                _                                               
  | |  | |                  / _|     | |              | |                                         
  | |__| |   ___     ___   | |_    __| |  ___    ___  | |__     ___   _ __   _ __ ___
  |  __  |  / _ \   / _ \  |  _|  / _` | / __|  / __| | '_ \   / _ \ | '__| | '_ ` _ \        
  | |  | | | (_) | | (_) | | |   | (_| | \__ \ | (__  | | | | |  __/ | |    | | | | | |    
  |_|  |_|  \___/   \___/  |_|    \__,_| |___/  \___| |_| |_|  \___| |_|    |_| |_| |_|
                                                                                      
                ";
                string underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                showHeader(color, title, underline);

                string[] options = new string[] {
                    "Reserveren",
                    "Films",
                    "Eten & Drinken",
                    "Informatie",
                    "Inloggen"
                };

                int choice = awaitResponse(options);
                CurrentScreen = options[choice];
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
