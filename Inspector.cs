using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideYouRent
{
    public class Inspector
    {
        //Attributes
        private string id;
        private string name;
        private string username;
        private string password;
        private string email;
        private string phone;

        //Empty Constructor
        public Inspector() { }

        //full constructor
        public Inspector(string id ,string name, string username, string password,
            string email, string phone)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phone = phone;
        }

        //Getters & Setters
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}