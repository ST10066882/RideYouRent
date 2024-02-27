using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace RideYouRent
{
    public class Validations
    {
        public Validations() { }

        public static bool ValidateString(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return  false;   
            }else if(double.TryParse(value,out double temp)==true)
            {
                return false;
            }
            return true;
        }
        public bool ValidateInspector(string name,string username,
            string password,string confirmPassword,string phone ,string email)
        {
            if (Validations.ValidateString(name) == true && Validations.ValidateString(username) == true)
            {
                if (phone.Length == 10  && Validations.ValidateString(email) == true)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}