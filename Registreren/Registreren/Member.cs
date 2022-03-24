using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Registreren
{
    public class Member: User
    {
        private Film[] History { get; set; }

        public Member(int id, string username, string password, string firstName, string surame, string gender, DateTime birthDate, string emailAddress) : 
            base(id, username, password, firstName, surame, gender, birthDate, emailAddress, "Member")
        {
            this.History = new Film[0];
        }

        private void showHeader()
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
        private void refresh()
        {
            Console.Clear();
            showHeader();
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

        // Maakt het gebruiker invulveld leeg.
        static void emptyField(string value, string field)
        {
            Console.CursorTop--;
            if (field == "jaar" || field == "maand" || field == "dag")
            {
                Console.CursorLeft = field.Length + 4;
            }
            else
            {
                Console.CursorLeft = 2;
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(value);
            Console.ResetColor();
            Console.CursorLeft = 0;
        }

        // Laat de error zien aan de gebruiker.
        private void showError(string field, string question, string error)
        {
            if (field == "maand" || field == "dag")
            {
                if (field == "maand")
                {
                    Console.CursorTop = Console.CursorTop - 2;
                }
                else
                {
                    Console.CursorTop = Console.CursorTop - 3;
                }
            }
            else
            {
                Console.CursorTop--;
            }
            Console.CursorLeft = question.Length;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(error);
            Console.ResetColor();

            if (field == "maand" || field == "dag")
            {
                if (field == "maand")
                {
                    Console.CursorTop = Console.CursorTop + 2;
                }
                else
                {
                    Console.CursorTop = Console.CursorTop + 3;
                }
            }
            else
            {
                Console.CursorTop++;
            }
            Console.CursorLeft = 0;
        }

        // Verbergt de error.
        private void hideError(string field, string question, string error)
        {
            if (field == "maand" || field == "dag")
            {
                if (field == "maand")
                {
                    Console.CursorTop = Console.CursorTop - 3;
                }
                else
                {
                    Console.CursorTop = Console.CursorTop - 4;
                }
            }
            else
            {
                Console.CursorTop = Console.CursorTop - 2;
            }
            Console.CursorLeft = question.Length + 1;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(error);
            Console.ResetColor();

            if (field == "maand" || field == "dag")
            {
                if (field == "maand")
                {
                    Console.CursorTop = Console.CursorTop + 3;
                }
                else
                {
                    Console.CursorTop = Console.CursorTop + 4;
                }
            }
            else
            {
                Console.CursorTop = Console.CursorTop + 2;
            }
            Console.CursorLeft = 0;
        }

        // Checkt of de e-mailadres geldig is
        private bool validEmail(string value)
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
        private bool emailExists(string value)
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
        private bool usernameExists(string value)
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
        private string checkErrors(string field, string question, int year = 0, int month = 0)
        {
            if (field == "jaar" || field == "maand" || field == "dag")
            {
                Console.CursorLeft = field.Length + 4;
            }
            else
            {
                Console.CursorLeft = 2;
            }
            string value = Console.ReadLine();
            bool errorsGone = false;
            string error = "";

            while (!errorsGone)
            {
                switch (value)
                {
                    case "":
                        error = " Het mag niet leeg zijn";
                        break;
                    case string a when a.Contains(" "):
                        error = " Geen spaties";
                        break;
                    case string a when a.Any(c => !char.IsLetter(c)) && (field != "emailAddress" && field != "wachtwoord"
                        && field != "jaar" && field != "maand" && field != "dag" && field != "gebruikersnaam"):
                        error = " Geen cijfers of andere symbolen";
                        break;
                    case string a when a.Length < 2 && field == "voornaam":
                        error = " Minimaal 2 karakters";
                        break;
                    case string a when a.Length < 6 && (field == "achternaam" || field == "gebruikersnaam" || field == "wachtwoord"):
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
                    case string a when a.Any(c => char.IsLetter(c)) && (field == "jaar" || field == "maand" || field == "dag"):
                        error = " Dit veld mag geen letters bevatten";
                        break;
                    case string a when a.Any(c => !char.IsLetter(c)) && field == "jaar":
                        if (int.Parse(a) > DateTime.Now.Year)
                        {
                            error = " Jaar kan niet groter zijn dan het huidige jaar";
                        }
                        break;
                    case string a when a.Any(c => !char.IsLetter(c)) && field == "maand":
                        if (int.Parse(a) < 1 || int.Parse(a) > 12)
                        {
                            error = " Maand moet tussen 1 en 12 inclusief zijn";
                        }
                        break;
                    case string a when a.Any(c => !char.IsLetter(c)) && field == "dag":
                        if (int.Parse(a) >= 1 && int.Parse(a) <= 31)
                        {
                            if (month != 2)
                            {
                                if ((month == 4 || month == 6 || month == 9 ||
                                    month == 11) && int.Parse(a) == 31)
                                {
                                    error = " Deze dag komt niet voor in uw maand";
                                }
                            }
                            else
                            {
                                bool isLeap = false;
                                if (int.Parse(a) == 29)
                                {
                                    if (year % 4 == 0)
                                    {
                                        if (year % 100 == 0)
                                        {
                                            if (year % 400 == 0)
                                            {
                                                isLeap = true;
                                            }
                                            else
                                            {
                                                isLeap = false;
                                            }
                                        }
                                        else
                                        {
                                            isLeap = true;
                                        }
                                    }
                                    else
                                    {
                                        isLeap = false;
                                    }
                                    if (!isLeap)
                                    {
                                        error = " Uw geboortejaar is geen schrikkeljaar en dus klopt het niet";
                                    }
                                }
                                else if (int.Parse(a) > 28)
                                {
                                    error = " Deze maand heeft niet het aantal dagen.";
                                }
                            }
                        }
                        else
                        {
                            error = " Dag kan alleen tussen 1 en 31 inclusief zijn";
                        }
                        break;
                }
                if (error != "")
                {
                    emptyField(value, field);
                    showError(field, question, error);
                    if (field == "jaar" || field == "maand" || field == "dag")
                    {
                        Console.CursorLeft = field.Length + 4;
                    }
                    else
                    {
                        Console.CursorLeft = 2;
                    }
                    value = Console.ReadLine();
                    hideError(field, question, error);
                    error = "";
                }
                else
                {
                    errorsGone = true;
                }
            }
            return value.ToString();
        }

        // Bewerkt de balk die verteld hoever je bent met registreren
        private void updateBar(int value, (int, int) cursorPosition, int count)
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
            }
            else
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
        private void makeAccount()
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

            string questionFour = "\n  [4] Wat is uw geboortedatum?";
            Console.WriteLine(questionFour);
            Console.Write("  Jaar: ");
            string year = checkErrors("jaar", questionFour);

            Console.Write("  Maand: ");
            string month = checkErrors("maand", questionFour);

            Console.Write("  Dag: ");
            string day = checkErrors("dag", questionFour, int.Parse(year), int.Parse(month));


            Tuple<int, int, int> collection = Tuple.Create(int.Parse(year), int.Parse(month), int.Parse(day));
            DateTime birthDate = new DateTime(collection.Item1, collection.Item2, collection.Item3);

            count++;
            currentPosition = Console.GetCursorPosition();
            updateBar(60, currentPosition, count);

            count++;
            refresh();
            currentPosition = Console.GetCursorPosition();
            updateBar(0, currentPosition, count);
            updateBar(80, currentPosition, count);

            string questionFive = "\n  [5] Wat is uw e-mailaddres?";
            Console.WriteLine(questionFive);
            string emailAddress = checkErrors("emailAddress", questionFive);

            string questionSix = "\n  [6] Welke gebruikersnaam wilt u?";
            Console.WriteLine(questionSix);
            string username = checkErrors("gebruikersnaam", questionSix);

            string questionSeven = "\n  [7] Wat wordt uw wachtwoord?";
            Console.WriteLine(questionSeven);
            string password = checkErrors("wachtwoord", questionSeven);

            count++;
            currentPosition = Console.GetCursorPosition();
            updateBar(100, currentPosition, count);

            string[] options = new string[]
            {
                    "Bevestigen",
            };

            int choice = awaitResponse(options);

            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<Member>>(jsonFile);

            Member member = new Member(users.Count + 1, username, password, firstname, surname, gender, birthDate, emailAddress);
            users.Add(member);
            var stringifiedUsers = JsonConvert.SerializeObject(users, Formatting.Indented);
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

        // Alle registraties weghalen.
        private void resetRegistrations()
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonFile);
            users.Clear();

            var stringifiedUsers = JsonConvert.SerializeObject(users);
            File.WriteAllText("../../../users.json", stringifiedUsers);

            refresh();
            showRegistrations();
        }

        // Laat accounts zien die momenteel geregistreerd staan.
        private void showRegistrations()
        {
            refresh();

            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonFile);

            if (users.Count == 0)
            {
                Console.WriteLine("  Er zijn geen geregistreerde gebruikers");
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.getRole() == "Member")
                    {
                        Console.WriteLine(user);
                        Console.WriteLine("  ---------------------------------------------");
                    }
                }
            }

            Console.WriteLine("");

            string[] options = new string[]
            {
                    "Registraties verwijderen",
                    "Terug",
            };

            int choice = awaitResponse(options);

            switch (choice)
            {
                case 0:
                    resetRegistrations();
                    break;
                case 1:
                    register();
                    break;
            }
        }

        // Registreren scherm.
        public static void register()
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
    }
}
