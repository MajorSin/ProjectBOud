class betalen
{
    public static void betaalOpties()
    {
        Console.WriteLine("Welkom op het betaalscherm."); // De user groeten en de betaal opties laten zien.
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Kies hier uw betaal methode:\n");
        Console.WriteLine("Druk op \"1\" voor iDeal.\n");
        Console.WriteLine("Druk op \"2\" voor PayPal.\n");
        Console.WriteLine("Druk op \"3\" voor CreditCard.\n");
        Console.WriteLine("Druk op \"4\" om te betalen op locatie.\n");
        Console.WriteLine("Druk op \"5\" om te betalen met Bitcoin.\n");
        Console.Write("Uw keuze: ");
        string betaalMethodeInput = Console.ReadLine(); //userinput lezen

        bool goedeKeuze = false;

        if (betaalMethodeInput == "1" || betaalMethodeInput == "2" || betaalMethodeInput == "3" || betaalMethodeInput == "4" || betaalMethodeInput == "5") // checken of de user een juiste input geeft
        {
            goedeKeuze = true;
        }

        while (!goedeKeuze)
        {
            Console.Write("Ongeldige invoer, kies A.U.B. uit het keuze menu hierboven: ");
            betaalMethodeInput = Console.ReadLine();

            if (betaalMethodeInput == "1" || betaalMethodeInput == "2" || betaalMethodeInput == "3" || betaalMethodeInput == "4" || betaalMethodeInput == "5") // zolang de user gheen goede input geeft krijgt hij de mogelijkheid om opniew een input te geven
            {
                goedeKeuze = true;
            }
        }
        if (betaalMethodeInput == "1")
        {
            Console.Clear();
            iDeal();
        }
        if (betaalMethodeInput == "2")
        {
            Console.Clear();
            payPal();
        }
    }

    public static void Main()
    {
        betaalOpties();
    }
    public static void iDeal()
    {
        Console.WriteLine("U heeft gekozen voor iDeal.\n");
        Console.WriteLine("Druk op het bijbehorende nummer van uw bank om die bank te kiezen.\nDruk op \"Q\" om terug te keren naar het vorige scherm.\n");
        Console.WriteLine("1:  ABN AMRO\n2:  ASN Bank\n3:  Bunq\n4:  ING\n5:  Knab\n6:  Rabobank\n7:  RegioBank\n8:  Revolut\n9:  SNS\n10: Svenska Handelsbanken\n11: Triodos Bank\n12: Van Landschot\n");
        Console.Write("Uw keuze: ");
        string bankInput = Console.ReadLine();

        if (bankInput == "Q" || bankInput == "q") // als de user q als input geeft gaat de user terug naar het vorige scherm
        {
            Console.Clear();
            betaalOpties();
        }

        bool goedeKeuze = false;

        if (bankInput == "1" || bankInput == "2" || bankInput == "3" || bankInput == "4" || bankInput == "5" || bankInput == "6" || bankInput == "7" || bankInput == "8" || bankInput == "9" || bankInput == "10" || bankInput == "11" || bankInput == "12" || bankInput == "q" || bankInput == "Q")
        {
            goedeKeuze = true;
        }

        while (!goedeKeuze)
        {
            Console.Write("Ongeldige invoer, kies A.U.B. uit het keuze menu hierboven: ");
            bankInput = Console.ReadLine();

            if (bankInput == "1" || bankInput == "2" || bankInput == "3" || bankInput == "4" || bankInput == "5" || bankInput == "6" || bankInput == "7" || bankInput == "8" || bankInput == "9" || bankInput == "10" || bankInput == "11" || bankInput == "12" || bankInput == "q" || bankInput == "Q")
            {
                goedeKeuze = true;
            }
        }
        if (bankInput == "q" || bankInput == "Q")
        {
            Console.Clear();
            betaalOpties();
        }
        if (bankInput == "1")
        {
            Console.Clear();
            ibanInvoer("ABN AMRO");
        }
        if (bankInput == "2")
        {
            Console.Clear();
            ibanInvoer("ASN Bank");
        }
        if (bankInput == "3")
        {
            Console.Clear();
            ibanInvoer("Bunq");
        }
        if (bankInput == "4")
        {
            Console.Clear();
            ibanInvoer("ING");
        }
        if (bankInput == "5")
        {
            Console.Clear();
            ibanInvoer("Knab");
        }
        if (bankInput == "6")
        {
            Console.Clear();
            ibanInvoer("Rabobank");
        }
        if (bankInput == "7")
        {
            Console.Clear();
            ibanInvoer("RegioBank");
        }
        if (bankInput == "8")
        {
            Console.Clear();
            ibanInvoer("Revolut");
        }
        if (bankInput == "9")
        {
            Console.Clear();
            ibanInvoer("SNS");
        }
        if (bankInput == "10")
        {
            Console.Clear();
            ibanInvoer("Svenska Handelsbanken");
        }
        if (bankInput == "11")
        {
            Console.Clear();
            ibanInvoer("Triodos Bank");
        }
        if (bankInput == "12")
        {
            Console.Clear();
            ibanInvoer("Van Landschot");
        }
    }
    public static void ibanInvoer(string bankKeuze)
    {
        Console.WriteLine($"U heeft gekozen voor {bankKeuze}.\n");
        Console.WriteLine("Vul hieronder uw IBAN nummer in.\n");
        Console.WriteLine("Wilt u naar het vorige scherm?\nDruk dan op \"Q\".\nLET OP: VUL HET IBAN NUMMER ZONDER SPATIES ER TUSSEN IN!");
        Console.Write("Uw IBAN nummer: ");
        string ibanInput = Console.ReadLine(); // de user krijgt de optie op zijn IBAN nummer in ter vullen
        bool ibanCorrect = false;
        if (ibanInput == "q" || ibanInput == "Q")
        {
            Console.Clear();
            iDeal();
        }
        if (ibanChecker(ibanInput)) // het IBAN nummer wordt op geldigheid gecheckt 
        {
            ibanCorrect = true;
        }
        while (!ibanCorrect)
        {
            Console.WriteLine("Dit is een ongeldig IBAN nummer.\nProbeer het nog een keer.\nLET OP: VUL HET IBAN NUMMER ZONDER SPATIES ER TUSSEN IN!");
            Console.Write("Uw IBAN nummer: ");
            ibanInput = Console.ReadLine();
            if (ibanInput == "q" || ibanInput == "Q")
            {
                Console.Clear();
                iDeal();
            }
            if (ibanChecker(ibanInput))
            {
                ibanCorrect = true;
            }
        }
        if (ibanCorrect)
        {
            Console.WriteLine("\nDe betaling is gelukt!\nDank u wel en geniet van uw film!");
        }
    }
    public static bool ibanChecker(string ibanInput)
    {
        if (ibanInput.Length != 18) // checkt of het IBAN nummer 18 karakters is
        {
            return false;
        }
        char[] ibanArray = new char[18];

        for (int i = 0; i < ibanArray.Length; i++)
        {
            ibanArray[i] = ibanInput[i];
            if (i == 0 || i == 1 || i == 4 || i == 5 || i == 6 || i == 7) // checkt of het 1e, 2e, 5e, 6e, 7e en 8e karakter een letter is
            {
                if (!charChecker(ibanArray[i]))
                {
                    return false;
                }
            }
            if (i == 2 || i == 3 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16 || i == 17) // checkt of het 3e, 4e, 9e, 10e, 11e, 12e, 13e, 14e, 15e, 16e, 17e en 18e karakter een cijfer is
            {
                if (!numberChecker(ibanArray[i]))
                {
                    return false;
                }
            }
        }
        return true;
    }
    public static bool charChecker(char c)
    {
        if (c == 'a' || c == 'b' || c == 'c' || c == 'd' || c == 'e' || c == 'f' || c == 'g' || c == 'h' || c == 'i' || c == 'j' || c == 'k' || c == 'l' || c == 'm' || c == 'n' || c == 'o' || c == 'p' || c == 'q' || c == 'r' || c == 's' || c == 't' || c == 'u' || c == 'v' || c == 'w' || c == 'x' || c == 'y' || c == 'z' || c == 'A' || c == 'B' || c == 'C' || c == 'D' || c == 'E' || c == 'F' || c == 'G' || c == 'H' || c == 'I' || c == 'J' || c == 'K' || c == 'L' || c == 'M' || c == 'N' || c == 'O' || c == 'P' || c == 'Q' || c == 'R' || c == 'S' || c == 'T' || c == 'U' || c == 'V' || c == 'W' || c == 'X' || c == 'Y' || c == 'Z')
        {
            return true; // checkt of een gegeven karakter een letter is
        }
        else
        {
            return false;
        }
    }
    public static bool numberChecker(char c)
    {
        if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
        {
            return true; // checkt of een gegeven karakter een cijfer is
        }
        else
        {
            return false;
        }
    }
    public static void payPal()
    {
        Console.WriteLine("U heeft gekozen voor PayPal.\n");
        Console.WriteLine("Vul hieronder uw Email adres en wachtwoord in.\n");
        Console.WriteLine("Wilt u naar het vorige scherm?\nDruk dan op \"Q\".\n");
        Console.Write("Uw Email adres: ");
        string eMailInput = Console.ReadLine();
        bool eMailCorrect = false;
        if (eMailInput == "q" || eMailInput == "Q")
        {
            Console.Clear();
            betaalOpties();
        }
        if (eMailChecker(eMailInput))
        {
            eMailCorrect = true;
        }
        while (!eMailCorrect)
        {

        }
    }
    public static bool eMailChecker(string eMail)
    {
        if (eMail.Contains('@') && eMail.Contains('.'))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}