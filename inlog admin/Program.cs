class inlog_admin
{
    public static void Main()
    {
        bool Admin_Rights = false;
        Console.WriteLine("would you like to login?");
        string login_status = Console.ReadLine();
        if (login_status == "yes")
        {
            Console.WriteLine("AdminName:");
               string Admin_Name = Console.ReadLine();
            Console.WriteLine("Admin_Password:");
            string Admin_Password = Console.ReadLine();
            if (Admin_Name == "admin123" && Admin_Password == "kersensaus15")
            {
                Console.WriteLine("Login succesful");
                Admin_Rights = true;

            }
            else if (Admin_Name != "admin123" && Admin_Password == "kersensaus15")
            {
                Console.WriteLine("Admin name not valid");

            }
            else if (Admin_Name == "admin123" && Admin_Password != "kersensaus15")
            {
                Console.WriteLine("Admin password not valid");

            }
            else
            {
                Console.WriteLine("Admin name and password not valid");
            }


        }
    }
}
