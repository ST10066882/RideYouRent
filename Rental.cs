using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;

namespace RideYouRent
{
    public class Rental
    {
        //Attributes
        private int rentalId;
        private string carNo;
        private string inspectorName;
        private string driverName;
        private int rentalFee;
        private DateTime startDate;
        private DateTime endDate;

        //Empty Constructor
        public Rental() { }

        //full Constructor
        public Rental(int rentalId, string carNo, string driverName, string inspectorName, int rentalFee, DateTime startDate, DateTime endDate)
        {
            this.rentalId = rentalId;
            this.carNo = carNo;
            this.driverName = driverName;
            this.inspectorName = inspectorName;
            this.rentalFee = rentalFee;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        //Getters & setters
        public int RentalId { get => rentalId; set => rentalId = value; }
        public string CarNo { get => carNo; set => carNo = value; }
        public string InspectorName { get => inspectorName; set => inspectorName = value; }
        public int RentalFee { get => rentalFee; set => rentalFee = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string DriverName { get => driverName; set => driverName = value; }
    }
}