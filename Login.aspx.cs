using RideYouRent.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RideYouRent
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string dbConnection = "Data Source=dbs-vc-cldv6211-st10066882.database.windows.net;Initial Catalog=db-vc-cldv6211-st10066882;Persist Security Info=True;User ID=st10066882;Password=Camphand55";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DBHelper db = new DBHelper();
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(dbConnection);
            string sqlQuery = ("select count(*) from inspector where username = '"+TextBox1.Text+"' and password = '"+TextBox2.Text+"'");
            SqlCommand getDetails = new SqlCommand(sqlQuery, connection);
            connection.Open();
            int find = int.Parse(getDetails.ExecuteScalar().ToString());
            connection.Close();
            if (find == 1)
            {
                Server.Transfer("Cars.aspx");
            }
            else
            {
                Label4.Text = "username or password is not correct";
            }
        }

        protected void ShowButton_Click(object sender, EventArgs e)
        {
            Label4.Text = "Username: " + TextBox1.Text + "\nPassword: " + TextBox2.Text;
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label4.Text = "";
        }
    }
}