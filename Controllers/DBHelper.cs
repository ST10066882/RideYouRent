using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RideYouRent.Controllers
{
    public class DBHelper
    {
        List<Inspector> listInspectors = new List<Inspector>();
        List<Car> listOfCars = new List<Car>();
        List<Driver> listOfDrivers = new List<Driver>();    
        List<Rental> listOfRentals = new List<Rental>();
        List<Return> listOfReturns = new List<Return>();

        string dbConnection = "Data Source=dbs-vc-cldv6211-st10066882.database.windows.net;Initial Catalog=db-vc-cldv6211-st10066882;Persist Security Info=True;User ID=st10066882;Password=Camphand55";
        public List<Inspector> InspectorsFromDatabase()
        {
            //Establish connection
            SqlConnection newConnection = new SqlConnection(dbConnection);

            //Creating command
            string newQuery = "SELECT * FROM inspector";

            //Opening connection to database
            newConnection.Open();

            //command that will execute query once connection established
            SqlCommand searchInspector = new SqlCommand(newQuery, newConnection);

            //Command to exceute reader
            SqlDataReader reader = searchInspector.ExecuteReader();

            while (reader.Read()) //Actions perfomred until you reach end of table
            {
                string id = reader.GetValue(0).ToString();
                string name = reader.GetValue(1).ToString();
                string phone = reader.GetValue(2).ToString();
                string email = reader.GetValue(3).ToString();
                string username = reader.GetValue(4).ToString();
                string password = reader.GetValue(5).ToString();

                Inspector newInspector = new Inspector(id, name, phone, email, username, password);
                listInspectors.Add(newInspector);
            }
            searchInspector.Dispose();
            newConnection.Close();

            return listInspectors;
        }

        public List<Car> CarsFromDatabase()
        {
            //Establish connection
            SqlConnection newConnection = new SqlConnection(dbConnection);

            //Creating command
            string newQuery = "SELECT car.carId,car.carNo,carMake.make_Name,carModel.model_Name," +
                "carBodyType.BodyType_Name,car.kilometersTravelled,car.kilometersServiced,car.availabilitys " +
                "from car " +
                "inner join carModel on car.model_Id = carModel.model_Id " +
                "inner join carMake on car.make_Id =carMake.make_Id " +
                "inner join carbodyType on car.bodyType_Id = carBodyType.bodyType_Id";

            //Opening connection to database
            newConnection.Open();

            //command that will execute query once connection established
            SqlCommand searchCar = new SqlCommand(newQuery, newConnection);

            //Command to exceute reader
            SqlDataReader reader = searchCar.ExecuteReader();

            while (reader.Read())
            {
                int carId = int.Parse(reader.GetValue(0).ToString());   
                string carNo = reader.GetValue(1).ToString();   
                string make = reader.GetValue(2).ToString();    
                string model = reader.GetValue(3).ToString();
                string bodyType = reader.GetValue(4).ToString();
                int kilometersTravelled = int.Parse(reader.GetValue(5).ToString());
                int kilometersServiced = int.Parse(reader.GetValue(6).ToString());
                string availability = reader.GetValue(7).ToString();

                Car newCar = new Car(carId,carNo,make,model,bodyType,kilometersTravelled, kilometersServiced,availability);
                listOfCars.Add(newCar);
            }
            searchCar.Dispose();
            newConnection.Close();
            return listOfCars;
        }
        public List<Driver> DriversFromDatabase()
        {
            //Establish connection
            SqlConnection newConnection = new SqlConnection(dbConnection);

            //Creating command
            string newQuery = "select * from driver";

            //Opening connection to database
            newConnection.Open();

            //command that will execute query once connection established
            SqlCommand searchCar = new SqlCommand(newQuery, newConnection);

            //Command to exceute reader
            SqlDataReader reader = searchCar.ExecuteReader();

            while (reader.Read())
            {
                int driverId = int.Parse(reader.GetValue(0).ToString());
                string fullName = reader.GetValue(1).ToString();
                string address = reader.GetValue(2).ToString();
                string email = reader.GetValue(3).ToString();
                string phone = reader.GetValue(4).ToString();

                Driver newDriver = new Driver(driverId,fullName,address,phone,email);
                listOfDrivers.Add(newDriver);
            }
            searchCar.Dispose();
            newConnection.Close();
            return listOfDrivers;
        }
        public List<Rental> RentalsFromDatabase()
        {
            //Establish connection
            SqlConnection newConnection = new SqlConnection(dbConnection);

            //Creating command
            string newQuery = "select rental.rentalId ,car.carNo,driver.driverFullName,inspector.inspectorFullName,rental.rentalFee,rental.startDate,rental.endDate " +
                "from rental " +
                "inner join car on rental.carId = car.carId " +
                "inner join driver on rental.driverId = driver.driverId " +
                "inner join inspector on rental.inspectorId = inspector.inspectorId";

            //Opening connection to database
            newConnection.Open();

            //command that will execute query once connection established
            SqlCommand searchRental = new SqlCommand(newQuery, newConnection);

            //Command to exceute reader
            SqlDataReader reader = searchRental.ExecuteReader();

            while (reader.Read())
            {
               int rentalId = int.Parse(reader.GetValue(0).ToString());
               string carNo =reader.GetValue(1).ToString();
               string inspectorName = reader.GetValue(2).ToString();
               string driverName = reader.GetValue(3).ToString();
               int rentalFee = int.Parse(reader.GetValue(4).ToString());
               DateTime startDate = (DateTime)reader.GetValue(5);
               DateTime endDate = (DateTime)reader.GetValue(6);

                Rental rental = new Rental(rentalId,carNo,driverName,inspectorName,rentalFee,startDate,endDate);
                listOfRentals.Add(rental);
            }
            searchRental.Dispose();
            newConnection.Close();
            return listOfRentals;
        }
        public List<Return> ReturnsFromDatabase()
        {
            //Establish connection
            SqlConnection newConnection = new SqlConnection(dbConnection);

            //Creating command
            string newQuery = "select car_Return.returnId ,car.carNo,driver.driverFullName,inspector.inspectorFullName,car_Return.returnDate,car_Return.elapsedDays " +
                "from car_Return " +
                "inner join rental on car_Return.rentalId = rental.rentalId " +
                "inner join car on rental.carId = car.carId " +
                "inner join driver on rental.driverId = driver.driverId " +
                "inner join inspector on car_Return.inspectorId = inspector.inspectorId";

            //Opening connection to database
            newConnection.Open();

            //command that will execute query once connection established
            SqlCommand searchReturn = new SqlCommand(newQuery, newConnection);

            //Command to exceute reader
            SqlDataReader reader = searchReturn.ExecuteReader();

            while (reader.Read())
            {
                int returnId = int.Parse(reader.GetValue(0).ToString());
                string rentalCarNo = reader.GetValue(1).ToString();
                string rentalDriverName = reader.GetValue(2).ToString();
                string inspectorName = reader.GetValue(3).ToString();
                string returnDate = reader.GetValue(4).ToString();
                int eplasedDays = int.Parse(reader.GetValue(5).ToString());

                Return newReturn = new Return(returnId,rentalCarNo,rentalDriverName,inspectorName,returnDate,eplasedDays);
                listOfReturns.Add(newReturn);
            }
            searchReturn.Dispose();
            newConnection.Close();
            return listOfReturns;
        }

    }
}