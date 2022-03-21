using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Registreren
{
    internal class Program
    {
        static void showHeader()
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

            Console.ForegroundColor = color;
            Console.WriteLine(@"{0}", title);
            Console.BackgroundColor = color;
            Console.WriteLine(underline);
            Console.ResetColor();
        }

        // Ververst het console-scherm.
        static void refresh()
        {
            Console.Clear();
            showHeader();
        }

        // Keuze van de gebruiker vaststellen.
        static int awaitResponse(string[] options)
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

        // Maakt het gebruiker invulveld leeg.
        static void emptyField(string field)
        {
            Console.CursorTop--;
            Console.CursorLeft = 2;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(field);
            Console.ResetColor();
            Console.CursorLeft = 0;
        }

        // Laat de error zien aan de gebruiker.
        static void showError(string question, string error)
        {
            Console.CursorTop--;
            Console.CursorLeft = question.Length;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(error);
            Console.ResetColor();
            Console.CursorTop++;
            Console.CursorLeft = 0;
        }

        // Verbergt de error.
        static void hideError(string question, string error)
        {
            Console.CursorTop = Console.CursorTop - 2;
            Console.CursorLeft = question.Length + 1;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(error);
            Console.ResetColor();
            Console.CursorTop = Console.CursorTop + 2;
            Console.CursorLeft = 0;
        }

        // Checkt of de e-mailadres geldig is
        static bool validEmail(string value)
        {
            var trimmedEmail = value.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        // Checkt of de e-mailadres al bestaat
        static bool emailExists(string value)
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonFile);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].getEmailAddress() == value)
                {
                    return false;
                }
            }

            return true;
        }

        // Checkt of de gebruikersnaam al bestaat
        static bool usernameExists(string value)
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonFile);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].getUsername() == value)
                {
                    return false;
                }
            }

            return true;
        }

        // Controleert op errors in de input van de gebruiker.
        static string checkErrors(string field, string question)
        {
            Console.CursorLeft = 2;
            string value = Console.ReadLine();
            bool errorsGone = false;
            string error = "";

            while (!errorsGone)
            {
                switch (value) {
                    case "":
                        error = " Het mag niet leeg zijn";
                        break;
                    case string a when a.Contains(" "):
                        error = " Geen spaties";
                        break;
                    case string a when a.Any(c => !char.IsLetter(c)) && (field != "emailAddress" && field != "gebruikersnaam" && field != "wachtwoord"):
                        error = " Geen cijfers of andere symbolen";
                        break;
                    case string a when a.Length < 2 && field == "voornaam":
                        error = " Minimaal 2 karakters";
                        break;
                    case string a when a.Length < 6 && (field == "achternaam"  || field == "gebruikersnaam" || field == "wachtwoord"):
                        error = " Minimaal 6 karakters";
                        break;
                    case string a when a.Length > 9 && (field == "voornaam" || field == "achternaam"):
                        error = " Maximaal 9 karakters";
                        break;
                    case string a when (a.ToLower() != "man" && a.ToLower() != "vrouw") && field == "geslacht":
                        error = " Geslacht niet juist";
                        break;
                    case string a when !validEmail(a) && field == "emailAddress":
                        error = " E-mail klopt niet";
                        break;
                    case string a when !emailExists(a) && field == "emailAddress":
                        error = " E-mail is al in gebruik door iemand anders";
                        break;
                    case string a when !usernameExists(a) && field == "gebruikersnaam":
                        error = " Gebruikersnaam bestaat al kies iets anders";
                        break;
                }
                if (error != "") {
                    emptyField(value);
                    showError(question, error);
                    Console.CursorLeft = 2;
                    value = Console.ReadLine();
                    hideError(question, error);
                    error = "";
                } else
                {
                    errorsGone = true;
                }
            }
            return value;
        }

        // Bewerkt de balk die verteld hoever je bent met registreren
        static void updateBar(int value, (int, int) cursorPosition, int count)
        {
            int procent = value;
            string bar = $"  {procent}% klaar:  ";
            Console.CursorTop = 13;
            Console.Write(bar);

            if (value == 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("                                                                 \n");
                Console.ResetColor();
            } else
            {
                Console.CursorLeft = bar.Length;
                Console.BackgroundColor = ConsoleColor.Green;
                for (int i = 0; i < count; i++)
                {
                    Console.Write("             ");
                }
                Console.ResetColor();
            }

            Console.SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2 + 1);
        }

        // Account aanmaken proces.
        static void makeAccount()
        {
            refresh();

            int count = 0;
            (int, int) currentPosition = Console.GetCursorPosition();
            updateBar(0, currentPosition, count);

            string questionOne = "\n  [1] Wat is uw naam?";
            Console.WriteLine(questionOne);
            string firstname = checkErrors("voornaam", questionOne);

            count++;
            currentPosition = Console.GetCursorPosition();
            updateBar(20, currentPosition, count);

            string questionTwo = "  [2] Wat is uw achternaam?";
            Console.WriteLine(questionTwo);
            string surname = checkErrors("achternaam", questionTwo);

            count++;
            currentPosition = Console.GetCursorPosition();
            updateBar(40, currentPosition, count);

            string questionThree = "  [3] Wat is uw geslacht? Man/Vrouw";
            Console.WriteLine(questionThree);
            string gender = checkErrors("geslacht", questionThree);

            count++;
            currentPosition = Console.GetCursorPosition();
            updateBar(60, currentPosition, count);

            string questionFour = "  [4] Wat is uw e-mailaddres?";
            Console.WriteLine(questionFour);
            string emailAddress = checkErrors("emailAddress", questionFour);

            count++;
            currentPosition = Console.GetCursorPosition();
            updateBar(80, currentPosition, count);

            refresh();
            currentPosition = Console.GetCursorPosition();
            updateBar(0, currentPosition, count);
            updateBar(80, currentPosition, count);

            string questionFive = "\n  [5] Welke gebruikersnaam wilt u?";
            Console.WriteLine(questionFive);
            string username = checkErrors("gebruikersnaam", questionFive);

            string questionSix = "\n  [6] Wat wordt uw wachtwoord?";
            Console.WriteLine(questionSix);
            string password = checkErrors("wachtwoord", questionSix);

            count++;
            currentPosition = Console.GetCursorPosition();
            updateBar(100, currentPosition, count);

            string[] options = new string[]
            {
                    "Bevestigen",
            };

            int choice = awaitResponse(options);

            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonFile);

            User user = new User(users.Count + 1, username, password, firstname, surname, gender, emailAddress);
            users.Add(user);
            var stringifiedUsers = JsonConvert.SerializeObject(users);
            File.WriteAllText("../../../users.json", stringifiedUsers);

            refresh();

            Console.WriteLine("  Account is gemaakt!\n");

            options = new string[]
            {
                    "Terug",
            };

            choice = awaitResponse(options);

            register();
        }

        // Laat accounts zien die momenteel geregistreerd staan.
        static void showRegistrations()
        {
            refresh();

            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonFile);

            if (users.Count == 0)
            {
                Console.WriteLine("  Er zijn geen geregistreerde gebruikers.");
            } else
            {
                foreach (var user in users)
                {
                    Console.WriteLine(user);
                    Console.WriteLine("  ---------------------------------------------");
                }
            }

            Console.WriteLine("");

            string[] options = new string[]
            {
                    "Terug",
            };

            int choice = awaitResponse(options);

            register();
        }

        // Registreren scherm.
        static void register()
        {
            Console.Clear();
            showHeader();

            string[] options = new string[]
            {
                    "Account maken",
                    "Registraties tonen"
            };

            int choice = awaitResponse(options);

            switch (choice)
            {
                case 0:
                    makeAccount();
                    break;
                case 1:
                    showRegistrations();
                    break;
            }
            Console.Clear();
        }

        static void Main(string[] args)
        {
            register();
        }
    }
}
