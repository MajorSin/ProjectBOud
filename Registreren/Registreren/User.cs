using Newtonsoft.Json;
using System;

namespace Registreren
{
    public class User
    {
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

        public User(int id, string username, string password, string firstName, string surame, string gender, string emailAddress)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.Surname = surame;
            this.Gender = gender;
            this.EmailAddress = emailAddress;
        }

        public string getUsername()
        {
            return this.Username;
        }

        public string getEmailAddress()
        {
            return this.EmailAddress;
        }

        public override string ToString()
        {
            return String.Format(
                "  Gebruikersnaam: {0}\n" +
                "  Voornaam: {1}\n" +
                "  Achternaam: {2}\n" +
                "  Geslacht: {3}\n" +
                "  Email Address: {4}",
                Username, FirstName, Surname, Gender, EmailAddress
            );
        }
    }
}
