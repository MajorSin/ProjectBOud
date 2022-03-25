using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Registreren
{ 
    public class User
    {
        static User CurrentUser { get; set; }

        [JsonProperty("id")]
        private int Id { get; set; }

        [JsonProperty("username")]
        private string Username { get; set; }

        [JsonProperty("password")]
        private string Password { get; set; }

        [JsonProperty("firstName")]
        private string FirstName { get; set; }

        [JsonProperty("surname")]
        private string Surname { get; set; }

        [JsonProperty("gender")]
        private string Gender { get; set; }

        [JsonProperty("emailAddress")]
        private string EmailAddress { get; set; }

        [JsonProperty("birthDate")]
        private DateTime BirthDate { get; set; }

        [JsonProperty("role")]
        private string Role { get; set; }

        public User(int id, string username, string password, string firstName, string surame, string gender, DateTime birthDate, string emailAddress, string role)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.Surname = surame;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.EmailAddress = emailAddress;
            this.Role = role;
        }

        protected static void VerifyLogin(string username, string password)
        {
            var jsonFile = File.ReadAllText("../../../users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonFile);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].GetUsername() == username)
                {
                    if (users[i].GetPassword() == password)
                    {
                        CurrentUser = users[i];
                    }
                }
            }
        }

        public void LogOut()
        {
            CurrentUser = null;
        }

        public static User GetUser()
        {
            if (CurrentUser != null)
            {
                return CurrentUser;
            }

            return null;
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public string GetUsername()
        {
            return this.Username;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public string GetEmailAddress()
        {
            return this.EmailAddress;
        }

        public string GetGender()
        {
            return this.Gender;
        }

        public string GetRole()
        {
            return this.Role;
        }

        public override string ToString()
        {
            return String.Format(
                "  Gebruikersnaam: {0}\n" +
                "  Voornaam: {1}\n" +
                "  Achternaam: {2}\n" +
                "  Geslacht: {3}\n" +
                "  Geboortedatum: {4}\n" +
                "  Email Address: {5}",
                Username, FirstName, Surname, Gender, BirthDate.ToString("dd-MM-yyyy"), EmailAddress
            );
        }
    }
}
