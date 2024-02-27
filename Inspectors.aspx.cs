using RideYouRent.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideYouRent
{
    public partial class Inspectors : Page
    {
        string dbConnection = "Data Source=dbs-vc-cldv6211-st10066882.database.windows.net;Initial Catalog=db-vc-cldv6211-st10066882;Persist Security Info=True;User ID=st10066882;Password=Camphand55";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

     
        protected void HideButton_Click(object sender, EventArgs e)
        {
            //Telling the gridView there is no data source for it
            GridView1.DataSource = null;
            //linking the null source to the gridview (won't display)
            GridView1.DataBind();

            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
        }

        DBHelper helper = new DBHelper();
        protected void ViewData_Click(object sender, EventArgs e)
        {
            List<Inspector> inspectors = helper.InspectorsFromDatabase();
            //Telling the gridView where it must get data from
            GridView1.DataSource = inspectors;
            //Links the gridView to the data source
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox7.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
            TextBox8.Text = GridView1.SelectedRow.Cells[2].Text.ToString();
            TextBox9.Text = GridView1.SelectedRow.Cells[3].Text.ToString();
            TextBox10.Text = GridView1.SelectedRow.Cells[4].Text.ToString();
            TextBox11.Text = GridView1.SelectedRow.Cells[5].Text.ToString();
            TextBox12.Text = GridView1.SelectedRow.Cells[6].Text.ToString();
        }

        protected void AddInspectorButton_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text;
            string fullName = TextBox2.Text;
            string phone = TextBox3.Text;
            string email = TextBox4.Text;
            string username = TextBox5.Text;
            string password = TextBox6.Text;

            string query = "insert into inspector(inspectorId,inspectorFullName,phone,email,username,password) values (@inspectorId,@inspectorFullName,@phone,@email,@username,@password)";
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();
                SqlCommand addInspector = new SqlCommand(query, connection);
                addInspector.Parameters.AddWithValue("@inspectorId", id);
                addInspector.Parameters.AddWithValue("@inspectorFullName", fullName);
                addInspector.Parameters.AddWithValue("@phone", phone);
                addInspector.Parameters.AddWithValue("@email", email);
                addInspector.Parameters.AddWithValue("@username", username);
                addInspector.Parameters.AddWithValue("@password", password);

                addInspector.ExecuteNonQuery();
                connection.Close();
            }
        }

        protected void SaveInspectorButton_Click(object sender, EventArgs e)
        {
            SqlConnection connectDatabase = new SqlConnection(dbConnection);
            //SQL code that adds a new record to carBodyTable
            string query = "update inspector set inspectorFullName = @inspectorFullName,phone = @phone,email = @email,username = @username,password = @password WHERE inspectorId = @inspectorId";

            using (SqlCommand updateInspector = new SqlCommand(query, connectDatabase))
            {
                updateInspector.Parameters.AddWithValue("@inspectorFullName", TextBox8.Text);
                updateInspector.Parameters.AddWithValue("@phone", TextBox9.Text);
                updateInspector.Parameters.AddWithValue("@email", TextBox10.Text);
                updateInspector.Parameters.AddWithValue("@username", TextBox11.Text);
                updateInspector.Parameters.AddWithValue("@password", TextBox12.Text);
                updateInspector.Parameters.AddWithValue("@inspectorId", TextBox7.Text);

                connectDatabase.Open();
                updateInspector.ExecuteNonQuery();
                connectDatabase.Close();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM inspector WHERE inspectorId = @inspectorId";

            using (SqlConnection connectDatabase = new SqlConnection(dbConnection))
            {
                SqlCommand delete = new SqlCommand(query, connectDatabase);
                delete.Parameters.AddWithValue("@inspectorId", TextBox7.Text);
                connectDatabase.Open();
                delete.ExecuteNonQuery();
                connectDatabase.Close();
            }
        }
    }
    
}