using Microsoft.Ajax.Utilities;
using RideYouRent.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;
using System.Xml.Linq;

namespace RideYouRent
{
    public partial class Register : System.Web.UI.Page
    {
        DBHelper helper = new DBHelper();
        string dbConnection = "Data Source=dbs-vc-cldv6211-st10066882.database.windows.net;Initial Catalog=db-vc-cldv6211-st10066882;Persist Security Info=True;User ID=ST10066882;Password=Camphand55";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Getting data from the helper class list
            List<Inspector> inspectors = helper.InspectorsFromDatabase();

            string id = GenerateId();//Method creates unque id for inspector
            //Data the user entred to register a new inspector
            string name = TextBoxName.Text.Trim();
            string username = TextBoxUsername.Text.Trim();
            string password = TextBoxPassword.Text.Trim();
            string confirmPassword = TextBoxConfirmPassword.Text.Trim();
            string phone = TextBoxPhone.Text.Trim();
            string email = TextBoxEmail.Text.Trim();

            bool valid = false;
            //Validate user input
            Validations vClass = new Validations();
            valid = vClass.ValidateInspector(name, username, password, confirmPassword, phone, email);

            if (valid == true) 
            {
                //Check if user data matches the existing inspector
                foreach (Inspector inspector in inspectors)
                {
                    if (inspector.Name == name) {
                        Label1.Text = "user exists with that data ! ";
                        valid = false;
                    }
                    else if (inspector.Username == username)
                    {
                        Label1.Text = "user exists with that data ! ";
                        valid = false;
                    }
                    else if (inspector.Password == password)
                    {
                        Label1.Text = "user exists with that password ! ";
                        valid = false;
                    }
                    else if (password != confirmPassword)
                    {
                        Label1.Text = "passwords dont match ! ";
                        valid = false;
                    }
                    else if (inspector.Email == email)
                    {
                        Label1.Text = "user exists with that email ! ";
                        valid = false;    
                    }
                    else if (inspector.Phone == phone)
                    {
                        Label1.Text = "user exists with that phone number ! ";
                        valid = false;
                    }
                }
                if (valid == true)
                {
                    //Add inspector to database
                    GetInspectorDetails(id, name, phone, email, username, password);
                }
            }
            else
            {
                Label1.Text = "Invalid data entered ! ";
            }
        }//End Of Button Method
        public void GetInspectorDetails(string id, string name, string phone,
            string email,string username ,string password)
        {
            //The SQL statement we will run 
            string query = "insert into inspector (inspectorId , inspectorFullName,phone,email,username,password) " +
                "values ( @inspectorNum,@inspectorName,@phone,@email,@username,@password) ";

            //Establishing the connection to the database
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                //Open the connection
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@inspectorId", id);
                command.Parameters.AddWithValue("@inspectorName", name);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                command.ExecuteNonQuery();
                connection.Close();
            }
            Inspector inspector = new Inspector(id,name, username, password, email, phone); 
            ClearData();
        } 
        public string GenerateId()
        {
            string newId = "";
            string idPrefix = "I";
            string query = "SELECT ISNULL( MAX(inspectorId) ,'0') FROM inspector";
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                newId = command.ExecuteScalar().ToString();
            }
            int idNum = 0;
            if (int.TryParse(newId.Substring(1),out idNum)) 
            {
                idNum++;
            }
            else { idNum = 1; }
            string genId = idPrefix + idNum.ToString();
            return genId;
        }
        public void ClearData()
        {
            TextBoxName.Text = "";
            TextBoxUsername.Text = "";
            TextBoxPassword.Text = "";
            TextBoxConfirmPassword.Text = "";
            TextBoxEmail.Text = "";
        }
    }
}