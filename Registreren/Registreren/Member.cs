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
            var jsonFile = File.ReadAllText("../../../films.json");
            var films = JsonConvert.DeserializeObject<List<Film>>(jsonFile);

            Film film1 = films[0];
            Film film2 = films[1];
            Film film3 = films[2];

            this.History = new Film[3] {
                new Film(film1.Id, film1.Titel, film1.Jaar, film1.Taal, film1.Looptijd, film1.Genre, film1.Directeur, film1.Acteurs, film1.Plot),
                new Film(film2.Id, film2.Titel, film2.Jaar, film2.Taal, film2.Looptijd, film2.Genre, film2.Directeur, film2.Acteurs, film2.Plot),
                new Film(film3.Id, film3.Titel, film3.Jaar, film3.Taal, film3.Looptijd, film3.Genre, film3.Directeur, film3.Acteurs, film3.Plot)
            };
        }

        public Film[] GetHistory()
        {
            return this.History;
        }

        private static void ShowHeader(string view)
        {
            ConsoleColor color = ConsoleColor.Cyan;
            string title = "";
            string underline = "";

            switch (view)
            {
                case "Gebruiker":
                    title = @"
    _____          _                      _   _                  
   / ____|        | |                    (_) | |                 
  | |  __    ___  | |__    _ __   _   _   _  | | __   ___   _ __ 
  | | |_ |  / _ \ | '_ \  | '__| | | | | | | | |/ /  / _ \ | '__|
  | |__| | |  __/ | |_) | | |    | |_| | | | |   <  |  __/ | |   
   \_____|  \___| |_.__/  |_|     \__,_| |_| |_|\_\  \___| |_|

                    ";
                    underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                    break;
                case "Registreren":
                    title = @"
   _____                   _         _                                       
  |  __ \                 (_)       | |                                      
  | |__) |   ___    __ _   _   ___  | |_   _ __    ___   _ __    ___   _ __  
  |  _  /   / _ \  / _` | | | / __| | __| | '__|  / _ \ | '__|  / _ \ | '_ \ 
  | | \ \  |  __/ | (_| | | | \__ \ | |_  | |    |  __/ | |    |  __/ | | | |
  |_|  \_\  \___|  \__, | |_| |___/  \__| |_|     \___| |_|     \___| |_| |_|
                   __/ |                                                    
                  |___/    

                    ";
                    underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                    break;
                case "Inloggen":
                    title = @"
   _____           _                                        
  |_   _|         | |                                       
    | |    _ __   | |   ___     __ _    __ _    ___   _ __  
    | |   | '_ \  | |  / _ \   / _` |  / _` |  / _ \ | '_ \ 
   _| |_  | | | | | | | (_) | | (_| | | (_| | |  __/ | | | |
  |_____| |_| |_| |_|  \___/   \__, |  \__, |  \___| |_| |_|
                               __/ |   __/ |               
                              |___/   |___/

                    ";
                    underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                    break;
                case "Geschiedenis":
                    title = @"
    _____                       _       _              _                  _       
   / ____|                     | |     (_)            | |                (_)      
  | |  __    ___   ___    ___  | |__    _    ___    __| |   ___   _ __    _   ___ 
  | | |_ |  / _ \ / __|  / __| | '_ \  | |  / _ \  / _` |  / _ \ | '_ \  | | / __|
  | |__| | |  __/ \__ \ | (__  | | | | | | |  __/ | (_| | |  __/ | | | | | | \__ \
   \_____|  \___| |___/  \___| |_| |_| |_|  \___|  \__,_|  \___| |_| |_| |_| |___/
                                                                                 
                    ";
                    underline = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                    break;
            }

            Console.ForegroundColor = color;
            Console.WriteLine(@"{0}", title);
            Console.BackgroundColor = color;
            Console.WriteLine(underline);
            Console.ResetColor();
        }

        // Ververst het console-scherm.
        private static void Refresh(string view)
        {
            Console.Clear();
            ShowHeader(view);
        }

        // Keuze van de gebruiker vaststellen.
        private static int AwaitResponse(string[] options)
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
        private static void EmptyField(string value, string field)
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
        private static void ShowError(string field, string question, string error)
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
        private static void HideError(string field, string question, string error)
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
        private static bool ValidEmail(string value)
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
        private static bool EmailExists(string value)
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<Member>>(jsonFile);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].GetEmailAddress() == value)
                {
                    return false;
                }
            }

            return true;
        }

        // Checkt of de gebruikersnaam al bestaat.
        private static bool UsernameExists(string value)
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<Member>>(jsonFile);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].GetUsername() == value)
                {
                    return false;
                }
            }

            return true;
        }

        // Controleert of de gebruiker wel bestaat.
        private static bool UserExists(string value) 
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<Member>>(jsonFile);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].GetUsername() == value)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckCredentials(string username, string password)
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<Member>>(jsonFile);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].GetUsername() == username)
                {
                    if (users[i].GetPassword() == password)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        // Controleert op errors in de input van de gebruiker.
        private static string CheckErrors(string field, string question, string username = "", int year = 0, int month = 0)
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
                        && field != "jaar" && field != "maand" && field != "dag" && field != "gebruikersnaam" 
                        && field != "username" && field != "password"):
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
                    case string a when !ValidEmail(a) && field == "emailAddress":
                        error = " E-mail klopt niet";
                        break;
                    case string a when !EmailExists(a) && field == "emailAddress":
                        error = " E-mail is al in gebruik door iemand anders";
                        break;
                    case string a when !UsernameExists(a) && field == "gebruikersnaam":
                        error = " Gebruikersnaam bestaat al kies iets anders";
                        break;
                    case string a when !UserExists(a) && field == "username":
                        error = " Gebruikersnaam bestaat niet";
                        break;
                    case string a when !CheckCredentials(username, a) && field == "password":
                        error = " Wachtwoord is incorrect.";
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
                    EmptyField(value, field);
                    ShowError(field, question, error);
                    if (field == "jaar" || field == "maand" || field == "dag")
                    {
                        Console.CursorLeft = field.Length + 4;
                    }
                    else
                    {
                        Console.CursorLeft = 2;
                    }
                    value = Console.ReadLine();
                    HideError(field, question, error);
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
        private static void UpdateBar(int value, (int, int) cursorPosition, int count)
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

        // Inloggen in het reserveringssysteem.
        private static void Login()
        {
            Refresh("Inloggen");

            string userCredential = "  Gebruikersnaam:";
            Console.WriteLine(userCredential);
            string username = CheckErrors("username", userCredential);

            string passwordCredential = "\n  Wachtwoord:";
            Console.WriteLine(passwordCredential);
            string password = CheckErrors("password", passwordCredential, username);

            VerifyLogin(username, password);

            Console.WriteLine();

            string[] options = new string[]
            {
                    "Log in"
            };

            int choice = AwaitResponse(options);

            Refresh("Inloggen");

            Console.WriteLine("  Ingelogd!\n");

            options = new string[]
            {
                    "Terug",
            };

            choice = AwaitResponse(options);

            Display();
        }

        // Account aanmaken proces.
        private static void Register()
        {
            Refresh("Registreren");

            int count = 0;
            (int, int) currentPosition = Console.GetCursorPosition();
            UpdateBar(0, currentPosition, count);

            string questionOne = "\n  [1] Wat is uw naam?";
            Console.WriteLine(questionOne);
            string firstname = CheckErrors("voornaam", questionOne);

            count++;
            currentPosition = Console.GetCursorPosition();
            UpdateBar(20, currentPosition, count);

            string questionTwo = "  [2] Wat is uw achternaam?";
            Console.WriteLine(questionTwo);
            string surname = CheckErrors("achternaam", questionTwo);

            count++;
            currentPosition = Console.GetCursorPosition();
            UpdateBar(40, currentPosition, count);

            string questionThree = "  [3] Wat is uw geslacht? Man/Vrouw";
            Console.WriteLine(questionThree);
            string gender = CheckErrors("geslacht", questionThree);

            string questionFour = "\n  [4] Wat is uw geboortedatum?";
            Console.WriteLine(questionFour);
            Console.Write("  Jaar: ");
            string year = CheckErrors("jaar", questionFour);

            Console.Write("  Maand: ");
            string month = CheckErrors("maand", questionFour);

            Console.Write("  Dag: ");
            string day = CheckErrors("dag", questionFour, "", int.Parse(year), int.Parse(month));


            Tuple<int, int, int> collection = Tuple.Create(int.Parse(year), int.Parse(month), int.Parse(day));
            DateTime birthDate = new DateTime(collection.Item1, collection.Item2, collection.Item3);

            count++;
            currentPosition = Console.GetCursorPosition();
            UpdateBar(60, currentPosition, count);

            count++;
            Refresh("Registreren");
            currentPosition = Console.GetCursorPosition();
            UpdateBar(0, currentPosition, count);
            UpdateBar(80, currentPosition, count);

            string questionFive = "\n  [5] Wat is uw e-mailaddres?";
            Console.WriteLine(questionFive);
            string emailAddress = CheckErrors("emailAddress", questionFive);

            string questionSix = "\n  [6] Welke gebruikersnaam wilt u?";
            Console.WriteLine(questionSix);
            string username = CheckErrors("gebruikersnaam", questionSix);

            string questionSeven = "\n  [7] Wat wordt uw wachtwoord?";
            Console.WriteLine(questionSeven);
            string password = CheckErrors("wachtwoord", questionSeven);

            count++;
            currentPosition = Console.GetCursorPosition();
            UpdateBar(100, currentPosition, count);

            string[] options = new string[]
            {
                    "Bevestigen",
            };

            int choice = AwaitResponse(options);

            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<Member>>(jsonFile);

            Member member = new Member(users.Count + 1, username, password, firstname, surname, gender, birthDate, emailAddress);
            users.Add(member);
            var stringifiedUsers = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("../../../users.json", stringifiedUsers);

            Refresh("Registreren");

            Console.WriteLine("  Account is gemaakt!\n");

            options = new string[]
            {
                    "Terug",
            };

            choice = AwaitResponse(options);

            Display();
        }

        // Alle registraties weghalen.
        private static void ResetRegistrations()
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonFile);
            users.Clear();

            var stringifiedUsers = JsonConvert.SerializeObject(users);
            File.WriteAllText("../../../users.json", stringifiedUsers);

            Refresh("Gebruiker");

            SetUser(null);
            ShowRegistrations();
        }

        // Laat accounts zien die momenteel geregistreerd staan.
        private static void ShowRegistrations()
        {
            Refresh("Gebruiker");

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
                    if (user.GetRole() == "Member")
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

            int choice = AwaitResponse(options);

            switch (choice)
            {
                case 0:
                    ResetRegistrations();
                    break;
                case 1:
                    Display();
                    break;
            }
        }

        // Laat geschiedenis zien van de gebruiker.
        public static void ShowHistory()
        {
            Refresh("Geschiedenis");

            User user = GetUser();
            Member member = null;

            var jsonFile = File.ReadAllText("../../../users.json");
            var members = JsonConvert.DeserializeObject<List<Member>>(jsonFile);

            for (int i = 0; i < members.Count; i++) { 
                if (members[i].GetUsername() == user.GetUsername())
                {
                    member = members[i];
                    break;
                }
            }

            Film[] films = member.GetHistory();

            for (int film = 0; film < films.Length; film++)
            {
                Console.WriteLine(films[film]);
                Console.WriteLine("  ---------------------------------------------");
            }

            Console.WriteLine("");

            string[] options = new string[]
            {
                    "Terug",
            };

            int choice = AwaitResponse(options);

            Display();
        }

        // Registreren scherm.
        public static void Display()
        {
            Refresh("Gebruiker");

            User user = GetUser();

            if (user != null)
            {
                Member member = null;

                var jsonFile = File.ReadAllText("../../../users.json");
                var users = JsonConvert.DeserializeObject<List<Member>>(jsonFile);

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].GetUsername() == user.GetUsername())
                    {
                        member = users[i];
                    }
                }

                Console.Write($"  Ingelogd als: ");
                Console.ForegroundColor = member.GetGender() == "Man" ? ConsoleColor.Blue : ConsoleColor.Magenta;
                Console.WriteLine($"{member.GetFirstName()}\n");
                Console.ResetColor();
            }

            Console.WriteLine("  Gebruik pijltjestoetsen ↑ en ↓ om te navigeren\n  en druk enter om een optie te kiezen.\n");

            string[] options = new string[]
            {
                    user != null ? "Uitloggen" : "Inloggen",
                    "Registreren",
                    "Registraties tonen",
                    user != null ? "Geschiedenis" : ""
            };

            int choice = AwaitResponse(options);

            switch (choice)
            {
                case 0:
                    if (user != null)
                    {
                        user.LogOut();
                        Display();
                    } else
                    {
                        Login();
                    }
                    break;
                case 1:
                    Register();
                    break;
                case 2:
                    ShowRegistrations();
                    break;
                case 3:
                    ShowHistory();
                    break;
            }

            Refresh("Gebruiker");
        }
    }
}
