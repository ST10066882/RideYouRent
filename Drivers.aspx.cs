using RideYouRent.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RideYouRent
{
    public partial class Drivers : Page
    {
        string dbConnection = "Data Source=dbs-vc-cldv6211-st10066882.database.windows.net;Initial Catalog=db-vc-cldv6211-st10066882;Persist Security Info=True;User ID=st10066882;Password=Camphand55";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get selected row data from table into textBoxes
            TextBox6.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            TextBox7.Text = GridView1.SelectedRow.Cells[2].Text.ToString();
            TextBox8.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            TextBox9.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
            TextBox10.Text = GridView1.SelectedRow.Cells[5].Text.ToString();
        }

        protected void HideButon_Click(object sender, EventArgs e)
        {
            //Telling the gridView there is no data source for it
            GridView1.DataSource = null;
            //linking the null source to the gridview (won't display)
            GridView1.DataBind();

            //Empty Textboxes
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";

        }

        DBHelper dB = new DBHelper();
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Getting driver info from DBHelper Class
            List<Driver> drivers = dB.DriversFromDatabase();
            //Telling the gridView where it must get data from
            GridView1.DataSource = drivers;
            //Links the gridView to the data source
            GridView1.DataBind();
        }

        protected void AddDriverButton_Click(object sender, EventArgs e)
        {
            List<Driver> drivers = dB.DriversFromDatabase();
            Driver driver = new Driver();
            //Get values from textboxes
            string driverId = TextBox1.Text;
            string fullName = TextBox2.Text;
            string address = TextBox5.Text;
            string phone = TextBox3.Text;
            string email = TextBox4.Text;

            if (driverId != "" && fullName != "" && address != "" && phone != "" && email != "")
            {
                if (int.TryParse(TextBox1.Text, out int temp) == false)
                {
                    Label17.Text = "Id must be integar";
                }else if (int.Parse(TextBox1.Text) <= drivers.Count)
                {
                    Label17.Text = "driver id exists already";
                }else if (int.TryParse(TextBox2.Text, out int temp2) == true) 
                {
                    Label17.Text = "driver name must be string";
                }
                else if (phone.Length > 11) 
                {
                    Label17.Text = "invalid phone number";
                }else if (Validations.ValidateString(address) == false) 
                {
                    Label17.Text = "invalid address";
                }
                else if (Validations.ValidateString(email) == false)
                {
                    Label17.Text = "invalid email";
                }
                else
                {
                    //Check if valid data entered
                    string query = "insert into driver(driverId, driverFullName,addresses,email,phone) values(@driverId,@driverFullName,@addresses,@email,@phone)";
                    using (SqlConnection connection = new SqlConnection(dbConnection))
                    {
                        //Add driver content
                        connection.Open();
                        try
                        {
                            SqlCommand addDriver = new SqlCommand(query, connection);
                            addDriver.Parameters.AddWithValue("@driverId", driverId);
                            addDriver.Parameters.AddWithValue("@driverFullName", fullName);
                            addDriver.Parameters.AddWithValue("@addresses", address);
                            addDriver.Parameters.AddWithValue("@email", email);
                            addDriver.Parameters.AddWithValue("@phone", phone);

                            addDriver.ExecuteNonQuery();
                            Label17.Text = "Driver Added";
                        }
                        catch (Exception ex)
                        {
                            Label17.Text =ex.Message;
                        }
                        connection.Close();
                    }
                }      
            }
            else 
            {
                Label17.Text = "Insuffcient data entered!";
            }
        }//End of method

        //Most likely works
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            List<Driver> drivers = dB.DriversFromDatabase();
            if (TextBox6.Text == "")
            {
                Label17.Text = "Please select from table first!";
            }
            else if (int.Parse(TextBox6.Text) > drivers.Count || int.Parse(TextBox6.Text) < 0)
            {
                Label17.Text = "Invalid driverId !";
            }
            else
            {
                string query = "DELETE FROM driver WHERE driverId = @driverId";

                using (SqlConnection connectDatabase = new SqlConnection(dbConnection))
                {
                    SqlCommand delete = new SqlCommand(query, connectDatabase);
                    delete.Parameters.AddWithValue("@driverId", TextBox6.Text);
                    connectDatabase.Open();
                    delete.ExecuteNonQuery();
                    connectDatabase.Close();
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            List<Driver> drivers = dB.DriversFromDatabase();
            if (TextBox6.Text != "" || TextBox7.Text != "" || TextBox8.Text != "" || TextBox9.Text != "" || TextBox10.Text != "")
            {
                if (int.TryParse(TextBox6.Text, out int temp) == false)
                {
                    Label17.Text = "Id must be integar";
                }
                else if (int.TryParse(TextBox7.Text, out int temp2) == true)
                {
                    Label17.Text = "driver name must be string";
                }
               
                else if (Validations.ValidateString(TextBox9.Text) == false)
                {
                    Label17.Text = "invalid address";
                }
                else if (Validations.ValidateString(TextBox10.Text) == false)
                {
                    Label17.Text = "invalid email";
                }
                else
                {
                    SqlConnection connectDatabase = new SqlConnection(dbConnection);
                    //SQL code that adds a new record to carBodyTable
                    string query = "update driver set driverFullName = @driverFullName, addresses = @addresses,email = @email,phone = @phone WHERE driverId = @driverId";

                    using (SqlCommand updateDriver = new SqlCommand(query, connectDatabase))
                    {
                        updateDriver.Parameters.AddWithValue("@driverFullName", TextBox7.Text);
                        updateDriver.Parameters.AddWithValue("@addresses", TextBox8.Text);
                        updateDriver.Parameters.AddWithValue("@email", TextBox9.Text);
                        updateDriver.Parameters.AddWithValue("@phone", TextBox10.Text);
                        updateDriver.Parameters.AddWithValue("@driverId", TextBox6.Text);

                        connectDatabase.Open();
                        updateDriver.ExecuteNonQuery();
                        connectDatabase.Close();
                    }
                }
            }
            else
            {
                Label17.Text = "all data fields must be entered";
            }
            
        }
    }  
}