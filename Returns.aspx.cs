using RideYouRent.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideYouRent
{
    public partial class Returns : System.Web.UI.Page
    {
        string dbConnection = "Data Source=dbs-vc-cldv6211-st10066882.database.windows.net;Initial Catalog=db-vc-cldv6211-st10066882;Persist Security Info=True;User ID=st10066882;Password=Camphand55";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DBHelper dB = new DBHelper(); 
        protected void ViewData_Click(object sender, EventArgs e)
        {
            List<Return> returns = dB.ReturnsFromDatabase();
            //Telling the gridView where it must get data from
            GridView1.DataSource = returns;
            //Links the gridView to the data source
            GridView1.DataBind();
        }

        protected void HideButton_Click(object sender, EventArgs e)
        {
            //Telling the gridView there is no data source for it
            GridView1.DataSource = null;
            //linking the null source to the gridview (won't display)
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




        protected void Button2_Click(object sender, EventArgs e)
        {
            string[] inspectorIds = ListOfIds();
            int returnId = int.Parse(TextBox1.Text);
            int rentalId = int.Parse(DropDownList4.SelectedValue);
            string inspectorId = inspectorIds[DropDownList3.SelectedIndex];
            DateTime returnDate = Calendar1.SelectedDate;
            int eplasedDays = int.Parse(TextBox2.Text);

            string query = "insert into car_Return(returnId,rentalId,inspectorId,returnDate,elapsedDays) values(@returnId,@rentalId,@inspectorId,@returnDate,@elapsedDays)";
            using (SqlConnection connectDatabase = new SqlConnection(dbConnection))
            {
                connectDatabase.Open();
                SqlCommand command = new SqlCommand(query, connectDatabase);
                command.Parameters.AddWithValue("@returnId", returnId);
                command.Parameters.AddWithValue("@rentalId", rentalId);
                command.Parameters.AddWithValue("@inspectorId", inspectorId);
                command.Parameters.AddWithValue("@returnDate", returnDate);
                command.Parameters.AddWithValue("@elapsedDays", eplasedDays);
                
                command.ExecuteNonQuery();
                connectDatabase.Close();
            }

        }
    }
}