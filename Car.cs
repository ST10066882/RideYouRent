using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideYouRent
{
    public class Car
    {
        //Attributes
        private int carId;
        private string carNo;
        private string make;
        private string model;
        private string bodyType;
        private int kilometersTravelled;
        private int kilometersServiced; 
        private string availability;

        //Empty Constructor
        public Car() { }

        //Full Constructor
        public Car(int carId, string carNo, string make, string model, string bodyType,
            int kilometersTravelled, int kilometersServiced, string availability)
        {
            this.carId = carId;
            this.carNo = carNo;
            this.make = make;
            this.model = model;
            this.bodyType = bodyType;
            this.kilometersTravelled = kilometersTravelled;
            this.kilometersServiced = kilometersServiced;
            this.availability = availability;
        }

        //Getters & Setters
        public int CarId { get => carId; set => carId = value; }
        public string CarNo { get => carNo; set => carNo = value; }
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public string BodyType { get => bodyType; set => bodyType = value; }
        public int KilometersTravelled { get => kilometersTravelled; set => kilometersTravelled = value; }
        public int KilometersServiced { get => kilometersServiced; set => kilometersServiced = value; }
        public string Availability { get => availability; set => availability = value; }
    }
}