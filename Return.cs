using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideYouRent
{
    public class Return
    {
        //Attributes
        private int returnId;
        private string rentalCarNo;
        private string rentalDriverName;
        private string inspectorName;
        private string returnDate;
        private int eplasedDays;

        //Empty constructor
        public Return() { }

        //full constructor
        public Return(int returnId, string rentalCarNo, string rentalDriverName, string inspectorName, string returnDate, int eplasedDays)
        {
            this.returnId = returnId;
            this.rentalCarNo = rentalCarNo;
            this.rentalDriverName = rentalDriverName;
            this.inspectorName = inspectorName;
            this.returnDate = returnDate;
            this.eplasedDays = eplasedDays;
        }

        //Getters & Setters
        public int ReturnId { get => returnId; set => returnId = value; }
        public string RentalCarNo { get => rentalCarNo; set => rentalCarNo = value; }
        public string RentalDriverName { get => rentalDriverName; set => rentalDriverName = value; }

        public string InspectorName { get => inspectorName; set => inspectorName = value; }
        public string ReturnDate { get => returnDate; set => returnDate = value; }
        public int EplasedDays { get => eplasedDays; set => eplasedDays = value; }

    }
}