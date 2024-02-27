using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideYouRent
{
    public class Driver
    {
        //Attributes
        private int driverId;
        private string fullName;
        private string address;
        private string phone;
        private string email;

        //Empty Constructor
        public Driver() { }

        //full Constructor
        public Driver(int driverId, string fullName, string address, string phone, string email)
        {
            this.driverId = driverId;
            this.fullName = fullName;
            this.address = address;
            this.phone = phone;
            this.email = email;
        }

        //Getters & Setters
        public int DriverId { get => driverId; set => driverId = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
    }
}