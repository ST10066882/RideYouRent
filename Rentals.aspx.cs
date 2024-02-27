using RideYouRent.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideYouRent
{
    public partial class Rentals : System.Web.UI.Page
    {
        string dbConnection = "Data Source=dbs-vc-cldv6211-st10066882.database.windows.net;Initial Catalog=db-vc-cldv6211-st10066882;Persist Security Info=True;User ID=st10066882;Password=Camphand55";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DBHelper db = new DBHelper();   
        protected void ViewDataButton_Click(object sender, EventArgs e)
        {
            List<Rental> rentals = db.RentalsFromDatabase();
            //Telling the gridView where it must get data from
            GridView1.DataSource = rentals;
            //Links the gridView to the data source
            GridView1.DataBind();
        }
        public string[] ListOfIds()
        {
            string[] ids = new string[20];

            //Establish connection
            SqlConnection newConnection = new SqlConnection(dbConnection);

            //Creating command
            string newQuery = "select rental.inspectorId from rental";

            //Opening connection to database
            newConnection.Open();

            //command that will execute query once connection established
            SqlCommand creatingList = new SqlCommand(newQuery, newConnection);
            int index = 0;
            //Command to exceute reader
            SqlDataReader reader = creatingList.ExecuteReader();
            while (reader.Read())
            {
                ids[index] = reader.GetString(0);
                index++;
            }
            newConnection.Close();
            return ids;
        }

        protected void AddREntalButton_Click(object sender, EventArgs e)
        {
            string []arrayOfIds = ListOfIds();
            //Make List of ids and try to match to list
            string rentalId = TextBox1.Text;
            int carId = DropDownList2.SelectedIndex + 1;
            string inspectorId = arrayOfIds[DropDownList4.SelectedIndex]  ;
            int driverId = DropDownList3.SelectedIndex + 1;
            int rentalFee = int.Parse(TextBox2.Text);
            DateTime startDate = Calendar1.SelectedDate;
            DateTime endDate = Calendar2.SelectedDate;

            string query = "insert into rental(rentalId,carId,driverId,inspectorId,rentalFee,startDate,endDate) values(@rentalId,@carId,@driverId,@inspectorId,@rentalFee,@startDate,@endDate)";
            using (SqlConnection connectDatabase = new SqlConnection(dbConnection)) 
            {
                connectDatabase.Open();
                SqlCommand command = new SqlCommand(query, connectDatabase);
                command.Parameters.AddWithValue("@rentalId", rentalId);
                command.Parameters.AddWithValue("@carId", carId);
                command.Parameters.AddWithValue("@driverId", driverId);
                command.Parameters.AddWithValue("@inspectorId", inspectorId);
                command.Parameters.AddWithValue("@rentalFee", rentalFee);
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@endDate", endDate);

                command.ExecuteNonQuery();
                connectDatabase.Close();
            }

        }
        protected void HideButton_Click(object sender, EventArgs e)
        {
            //Telling the gridView there is no data source for it
            GridView1.DataSource = null;
            //linking the null source to the gridview (won't display)
            GridView1.DataBind();
        }
    }
}