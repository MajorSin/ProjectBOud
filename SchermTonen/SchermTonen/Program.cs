using System;
using System.Collections.Generic;
using System.Linq;

namespace SchermTonen
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Maakt een Router instantie om te gebruiken voor de schermen.
            Router router = new Router();
            router.displayScreen();
        }
    }
}
